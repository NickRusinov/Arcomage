using System;
using System.Collections.Generic;
using System.Linq;
using Arcomage.Domain;
using Arcomage.Domain.Buildings;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Hands;
using Arcomage.Domain.Histories;
using Arcomage.Domain.Players;
using Arcomage.Domain.Resources;
using Arcomage.Domain.Timers;
using Arcomage.Network;
using Arcomage.WebApi.Models.Game;
using AutoMapper;
using static System.Math;

namespace Arcomage.WebApi
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<(GameContext c, Game g), GameModel>()
                .ForMember(m => m.FirstPlayer, exp => exp.ResolveUsing(t => (t.c.FirstUser, t.g.Players.FirstPlayer)))
                .ForMember(m => m.SecondPlayer, exp => exp.ResolveUsing(t => (t.c.SecondUser, t.g.Players.SecondPlayer)))
                .ForMember(m => m.History, exp => exp.ResolveUsing(t => t.g.History))
                .ForMember(m => m.Hand, exp => exp.ResolveUsing(t => (t.g, t.g.Players.FirstPlayer, t.g.Players.FirstPlayer.Hand)))
                .ForMember(m => m.Timer, exp => exp.ResolveUsing(t => t.g.Timer))
                .ForMember(m => m.Result, exp => exp.ResolveUsing(t => (t.c, t.g.Rule.IsWin(t.g))))
                .ForMember(m => m.Result, exp => exp.PreCondition(t => t.g.Rule.IsWin(t.g)))
                .ForMember(m => m.PlayAgain, exp => exp.MapFrom(t => t.g.PlayAgain))
                .ForMember(m => m.DiscardOnly, exp => exp.MapFrom(t => t.g.DiscardOnly))
                .ForMember(m => m.Version, exp => exp.MapFrom(t => t.c.Version));

            CreateMap<(UserContext c, Player p), GameModel.PlayerModel>()
                .ForMember(m => m.Name, exp => exp.ResolveUsing(t => t.c.Id.ToString()))
                .ForMember(m => m.Buildings, exp => exp.ResolveUsing(t => t.p.Buildings))
                .ForMember(m => m.Resources, exp => exp.ResolveUsing(t => t.p.Resources));

            CreateMap<BuildingSet, GameModel.BuildingsModel>()
                .ForMember(m => m.MaxWall, exp => exp.UseValue(50)) // TODO
                .ForMember(m => m.MaxTower, exp => exp.UseValue(50)); // TODO

            CreateMap<ResourceSet, GameModel.ResourcesModel>();

            CreateMap<History, GameModel.HistoryModel>();
            CreateMap<HistoryCard, GameModel.HistoryCardModel>()
                .ForMember(m => m.Identifier, exp => exp.ResolveUsing(c => c.Card.GetIdentifier()))
                .ForMember(m => m.Index, exp => exp.MapFrom(c => c.Card.Index))
                .ForMember(m => m.ResourceKind, exp => exp.MapFrom(c => c.Card.Kind))
                .ForMember(m => m.ResourcePrice, exp => exp.MapFrom(c => c.Card.Price));

            CreateMap<(Game g, Player p, Hand h), GameModel.HandModel>()
                .ForMember(m => m.Cards, exp => exp.ResolveUsing(t => t.h.Cards.Select((c, i) => (t.g, t.p, c, i))));
            CreateMap<(Game g, Player p, Card c, int i), GameModel.CardModel>()
                .ForMember(m => m.Identifier, exp => exp.ResolveUsing(t => t.c.GetIdentifier()))
                .ForMember(m => m.Index, exp => exp.MapFrom(t => t.c.Index))
                .ForMember(m => m.ResourceKind, exp => exp.MapFrom(t => t.c.Kind))
                .ForMember(m => m.ResourcePrice, exp => exp.MapFrom(t => t.c.Price))
                .ForMember(m => m.CanPlay, exp => exp.ResolveUsing(t => t.g.PlayAction.CanPlay(t.g, t.p, new PlayResult(t.i, true))))
                .ForMember(m => m.CanDiscard, exp => exp.ResolveUsing(t => t.g.PlayAction.CanPlay(t.g, t.p, new PlayResult(t.i, false))));

            CreateMap<Timer, GameModel.TimerModel>()
                .ForMember(m => m.TimeRest, exp => exp.ResolveUsing(t => (int)Max(t.TimeRest.TotalSeconds, -1)));

            CreateMap<(GameContext c, GameResult r), GameModel.ResultModel>()
                .ForMember(m => m.Identifier, exp => exp.ResolveUsing(t => t.r.GetIdentifier()))
                .ForMember(m => m.WinPlayer, exp => exp.ResolveUsing(t => t.c.GetName(t.r.Player)));
        }
    }
}