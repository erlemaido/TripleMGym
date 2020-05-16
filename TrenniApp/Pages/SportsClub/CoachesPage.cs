﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public abstract class CoachesPage : CommonPage<ICoachesRepository, Coach, CoachView, CoachData>
    {
        protected internal readonly ITimetableEntriesRepository timetableEntries;

        protected internal CoachesPage(ICoachesRepository c, ITimetableEntriesRepository t, ITrainingTypesRepository tt, ITrainingsRepository tr, ILocationsRepository l) : base(c)
        {
            PageTitle = "Coaches";
            TimetableEntries = new List<TimetableEntryView>();
            timetableEntries = t;
            Trainings = CreateTrainingsSelectList<Training>(tr);
            Coaches = CreateCoachesSelectList<Coach>(c);
            Locations = CreateLocationsSelectList<Location>(l);
            TrainingTypes = CreateTrainingTypesSelectList<TrainingType>(tt);

        }

        protected CoachesPage(ICoachesRepository c, ITimetableEntriesRepository t) : base(c)
        {
            PageTitle = "Coaches";
            TimetableEntries = new List<TimetableEntryView>();
            timetableEntries = t;
        }

        public IList<TimetableEntryView> TimetableEntries { get; }

        public IEnumerable<SelectListItem> Trainings { get; }

        public IEnumerable<SelectListItem> Coaches { get; }

        public IEnumerable<SelectListItem> Locations { get; }

        public IEnumerable<SelectListItem> TrainingTypes { get; }

        public override string ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/SportsClub/Coaches";

        protected internal override Coach ToObject(CoachView view)
        {
            return CoachViewFactory.Create(view);
        }

        protected internal override CoachView ToView(Coach obj)
        {
            return CoachViewFactory.Create(obj);
        }

        public void LoadDetails(CoachView item)
        {
            TimetableEntries.Clear();

            if (item is null) return;
            timetableEntries.FixedFilter = GetMember.Name<TimetableEntryData>(x => x.CoachId);
            timetableEntries.FixedValue = item.Id;
            var list = timetableEntries.Get().GetAwaiter().GetResult();

            foreach (var e in list)
            {
                TimetableEntries.Add(TimetableEntryViewFactory.Create(e));
            }
        }

        private IEnumerable<SelectListItem> CreateTrainingsSelectList<Training>(IRepository<Training> r)
            where Training : Entity<TrainingData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(m.Data.Title, m.Data.Id)).ToList();
        }

        private IEnumerable<SelectListItem> CreateCoachesSelectList<Coach>(IRepository<Coach> r)
            where Coach : Entity<CoachData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(m.Data.FirstName + " " + m.Data.LastName, m.Data.Id)).ToList();
        }

        private IEnumerable<SelectListItem> CreateLocationsSelectList<Location>(IRepository<Location> r)
            where Location : Entity<LocationData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(m.Data.Code, m.Data.Id)).ToList();
        }

        private IEnumerable<SelectListItem> CreateTrainingTypesSelectList<TrainingType>(IRepository<TrainingType> r)
            where TrainingType : Entity<TrainingTypeData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(m.Data.Type, m.Data.Id)).ToList();
        }
    }
}

