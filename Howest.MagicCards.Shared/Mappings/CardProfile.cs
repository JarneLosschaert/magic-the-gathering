using AutoMapper;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.Shared.Mappings
{
    public class CardProfile: Profile
    {
       public CardProfile()
        {
            CreateMap<Card, CardReadDTO>()
                .ForMember(dto => dto.ArtistFullName,
                            opt => opt.MapFrom(a => a.Artist.FullName))
                .ForMember(dto => dto.SetName,
                            opt => opt.MapFrom(s => s.Set.Name))
                .ForMember(dto => dto.RarityName,
                            opt => opt.MapFrom(r => r.Rarity.Name));

            CreateMap<Card, CardDetailReadDTO>()
                .ForMember(dto => dto.ArtistFullName,
                            opt => opt.MapFrom(a => a.Artist.FullName))
                .ForMember(dto => dto.SetName,
                            opt => opt.MapFrom(s => s.Set.Name))
                .ForMember(dto => dto.RarityName,
                            opt => opt.MapFrom(r => r.Rarity.Name))
                .ForMember(dto => dto.ColorName,
                            opt => opt.MapFrom(c => c.CardColors.Select(cc => cc.Color.Name)))
                .ForMember(dto => dto.TypeNames,
                            opt => opt.MapFrom(c => c.CardTypes.Select(ct => ct.Type.Name)));
        }
            
    }
}
