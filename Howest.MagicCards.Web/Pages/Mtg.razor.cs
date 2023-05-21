using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;
using Howest.MagicCards.Shared.ViewModels;
using Howest.MagicCards.WebAPI.Wrappers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;

namespace Howest.MagicCards.Web.Pages;

public partial class Mtg
{
    private CardFilterViewModel _filter;
    private int _PageNumber = 1;
    private int _PageSize = 150;
    private int _totalPages = 0;
    private int _totalDeckCards = 0;
    private int _maxDeckCards = 60;

    private IEnumerable<CardDetailReadDTO> _cards = null;
    private IEnumerable<CardDeck> _deck = null;
    private IEnumerable<RarityReadDTO> _rarities = new List<RarityReadDTO>();
    private readonly JsonSerializerOptions _jsonOptions;
    private HttpClient _httpClient;
    private HttpClient _httpClientDeck;

    [Inject]
    public IHttpClientFactory? HttpClientFactory { get; set; }

    public Mtg()
    {
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    protected override async Task OnInitializedAsync()
    {
        _filter = new CardFilterViewModel();

        _httpClient = HttpClientFactory.CreateClient("CardsApi");
        _httpClientDeck = HttpClientFactory.CreateClient("DeckApi");
        await LoadCards();
        await LoadDeck();
        await LoadRarities();
    }

    private async Task LoadCards()
    {
        HttpResponseMessage response = await _httpClient.GetAsync(
                                                             $"cards?" +
                                                             GetFilter("SetName", _filter.SetName) +
                                                             GetFilter("ArtistName", _filter.ArtistName) +
                                                             GetFilter("RarityName", _filter.RarityName) +
                                                             GetFilter("CardType", _filter.CardType) +
                                                             GetFilter("CardText", _filter.CardText) +
                                                             GetFilter("CardName", _filter.CardName) +
                                                             $"PageNumber={_PageNumber}&" +
                                                             $"PageSize={_PageSize}&" +
                                                             $"OrderByNameAscending={_filter.OrderByNameAscending}"
                                                             );

        string apiResponse = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            PagedResponse<IEnumerable<CardDetailReadDTO>> result =
                   JsonSerializer.Deserialize<PagedResponse<IEnumerable<CardDetailReadDTO>>>(apiResponse, _jsonOptions);
            _cards = result.Data;
            _totalPages= result.TotalPages;
        }
        else
        {
            _cards = new List<CardDetailReadDTO>();
        }
    }

    private async Task LoadRarities()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("rarities");

        string apiResponse = await response.Content.ReadAsStringAsync();

        IEnumerable<RarityReadDTO> StartRarities = new List<RarityReadDTO>(new RarityReadDTO[] { new RarityReadDTO { Id = 0, Name = "", Code = "" }});

        if (response.IsSuccessStatusCode)
        {
            IEnumerable<RarityReadDTO> result =
                   JsonSerializer.Deserialize<IEnumerable<RarityReadDTO>>(apiResponse, _jsonOptions);
            _rarities = StartRarities.Concat(result);
        }
        else
        {
            _rarities = new List<RarityReadDTO>();
        }
    }

    private async Task LoadDeck()
    {
        HttpResponseMessage response = await _httpClientDeck.GetAsync("cards");

        string apiResponse = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            IEnumerable<CardDeck> result = JsonSerializer.Deserialize<IEnumerable<CardDeck>>(apiResponse, _jsonOptions);
            _deck = result;
            _totalDeckCards = GetTotalDeckCards();
        }
        else
        {
            _deck = new List<CardDeck>();
        }
    }

    private int GetTotalDeckCards()
    {
        int res = 0;
        foreach (var card in _deck)
        {
            res += card.Amount;
        }
        return res;
    }

    private async Task AddCard(long? Id, string Name)
    {
        if (_totalDeckCards < 60)
        {
            var cardToAdd = new CardDeck
            {
                Id = Id.HasValue ? (long)Id : 1,
                Name = Name,
                Amount = 1
            };

            var json = JsonSerializer.Serialize(cardToAdd);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClientDeck.PostAsync("cards", content);

            if (response.IsSuccessStatusCode)
            {
                await LoadDeck();
            }
        }
    }

    private async Task RemoveCard(long? Id)
    {
        HttpResponseMessage response = await _httpClientDeck.DeleteAsync("cards/" + Id);

        if (response.IsSuccessStatusCode)
        {
            await LoadDeck();
        }
    }

    private async Task ClearDeck()
    {
        HttpResponseMessage response = await _httpClientDeck.DeleteAsync("cards");

        if (response.IsSuccessStatusCode)
        {
            await LoadDeck();
        }
    }


    private static string GetFilter(string name, string value)
    {
        if (value == "")
        {
            return "";
        }
        else
        {
            return $"{name}={value}&";
        }
    }

    private void ToggleSort()
    {
        _PageNumber = 1;
        _filter.OrderByNameAscending = !_filter.OrderByNameAscending;
    }

    private async Task NextPage()
    {
        _PageNumber++;
        await LoadCards();
    }

    private async Task PreviousPage()
    {
        _PageNumber--;
        await LoadCards();
    }
}