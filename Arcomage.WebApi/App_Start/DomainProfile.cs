using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Arcomage.Domain;
using Arcomage.Domain.Buildings;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Hands;
using Arcomage.Domain.Histories;
using Arcomage.Domain.Players;
using Arcomage.Domain.Resources;
using Arcomage.Network;
using Arcomage.WebApi.Models.Game;
using AutoMapper;

namespace Arcomage.WebApi
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Game, GameModel>()
                .ForMember(m => m.FirstPlayer, exp => exp.MapFrom(g => g.Players.FirstPlayer))
                .ForMember(m => m.SecondPlayer, exp => exp.MapFrom(g => g.Players.SecondPlayer))
                .ForMember(m => m.Hand, exp => exp.MapFrom(g => g.Players.FirstPlayer.Hand))
                .ForMember(m => m.Result, exp => exp.ResolveUsing(g => g.Rule.IsWin(g)))
                .ForMember(m => m.Result, exp => exp.PreCondition(g => g.Rule.IsWin(g)));
            CreateMap<GameContext, GameModel>()
                .ForMember(m => m.FirstPlayer, exp => exp.MapFrom(c => c.FirstUser))
                .ForMember(m => m.SecondPlayer, exp => exp.MapFrom(c => c.SecondUser))
                .ForAllOtherMembers(exp => exp.Ignore());

            CreateMap<Player, GameModel.PlayerModel>()
                .ForMember(m => m.Name, exp => exp.Ignore());
            CreateMap<UserContext, GameModel.PlayerModel>()
                .ForMember(m => m.Name, exp => exp.ResolveUsing(c => c.Id.ToString()))
                .ForAllOtherMembers(exp => exp.Ignore());

            CreateMap<BuildingSet, GameModel.BuildingsModel>()
                .ForMember(m => m.MaxWall, exp => exp.UseValue(50)) // TODO
                .ForMember(m => m.MaxTower, exp => exp.UseValue(50)); // TODO

            CreateMap<ResourceSet, GameModel.ResourcesModel>();

            CreateMap<History, GameModel.HistoryModel>()
                .ForMember(m => m.Cards, exp => exp.ResolveUsing(h => h.Cards.Select((c, i) => (c, i))));
            CreateMap<(HistoryCard Card, int Index), GameModel.HistoryCardModel>()
                .ForMember(m => m.Identifier, exp => exp.UseValue("Apprentice")) // TODO
                .ForMember(m => m.Index, exp => exp.MapFrom(c => c.Index))
                .ForMember(m => m.ResourceKind, exp => exp.MapFrom(c => c.Card.Card.Kind))
                .ForMember(m => m.ResourcePrice, exp => exp.MapFrom(c => c.Card.Card.Price))
                .ForMember(m => m.IsPlayed, exp => exp.MapFrom(c => c.Card.IsPlayed));

            CreateMap<Hand, GameModel.HandModel>()
                .ForMember(m => m.Cards, exp => exp.ResolveUsing(h => h.Cards.Select((c, i) => (c, i))));
            CreateMap<(Card Card, int Index), GameModel.CardModel>()
                .ForMember(m => m.Identifier, exp => exp.UseValue("Apprentice")) //TODO
                .ForMember(m => m.Index, exp => exp.MapFrom(c => c.Index))
                .ForMember(m => m.ResourceKind, exp => exp.MapFrom(c => c.Card.Kind))
                .ForMember(m => m.ResourcePrice, exp => exp.MapFrom(c => c.Card.Price));

            CreateMap<GameResult, GameModel.ResultModel>()
                .ForMember(m => m.Identifier, exp => exp.UseValue("BuildTower")) // TODO
                .ForMember(m => m.WinPlayer, exp => exp.UseValue("FirstPlayer")); // TODO
        }
    }
}