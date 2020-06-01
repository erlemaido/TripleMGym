using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public abstract class TrainingsPage : CommonPage<ITrainingsRepository, Training, TrainingView, TrainingData>
    {
        protected internal readonly ITimetableEntriesRepository timetableTrainings;
        public IList<TimetableEntryView> TimetableTrainings { get; }
        public IEnumerable<SelectListItem> TrainingCategories { get; }
        public IEnumerable<SelectListItem> Coaches { get; }
        public IEnumerable<SelectListItem> TrainingTypes { get; }
        public IEnumerable<SelectListItem> Locations { get; }

        protected internal TrainingsPage(ITrainingsRepository trainingsRepository, ITimetableEntriesRepository timetableEntriesRepository, 
            ITrainingCategoriesRepository trainingCategoriesRepository, ICoachesRepository coachesRepository,
            ITrainingTypesRepository trainingTypesRepository, ILocationsRepository locationsRepository) : base(trainingsRepository)
        {
            PageTitle = "Treeningud";
            TimetableTrainings = new List<TimetableEntryView>();
            timetableTrainings = timetableEntriesRepository;
            TrainingCategories = CreateSelectList<TrainingCategory, TrainingCategoryData>(trainingCategoriesRepository);
            TrainingTypes = CreateSelectList<TrainingType, TrainingTypeData>(trainingTypesRepository);
            Locations = CreateSelectList<Location, LocationData>(locationsRepository);
            Coaches = CreateSelectList<Coach, CoachData>(coachesRepository);
        }

        public override string ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/SportsClub/Trainings";

        protected internal override Training ToObject(TrainingView view)
        {
            return TrainingViewFactory.Create(view);
        }

        protected internal override TrainingView ToView(Training obj)
        {
            return TrainingViewFactory.Create(obj);
        }

        public string GetTrainingCategoryName(string trainingCategoryId)
        {
            foreach (var m in TrainingCategories)
            {
                if (m.Value == trainingCategoryId)
                    return m.Text;
            }

            return "Määramata";
        }
        
        public string GetCoachName(string coachId)
        {
            foreach (var m in Coaches)
            {
                if (m.Value == coachId)
                    return m.Text;
            }

            return "Määramata";
        }
        
        public string GetTrainingTypeName(string trainingTypeId)
        {
            foreach (var m in TrainingTypes)
            {
                if (m.Value == trainingTypeId)
                    return m.Text;
            }

            return "Määramata";
        }
        
        public string GetLocationName(string locationId)
        {
            foreach (var m in Locations)
            {
                if (m.Value == locationId)
                    return m.Text;
            }

            return "Määramata";
        }

        public void LoadDetails(TrainingView item)
        {
            TimetableTrainings.Clear();

            if (item is null) return;
            timetableTrainings.FixedFilter = GetMember.Name<TimetableEntryData>(x => x.TrainingId);
            timetableTrainings.FixedValue = item.Id;
            var list = timetableTrainings.Get().GetAwaiter().GetResult();

            foreach (var e in list)
            {
                TimetableTrainings.Add(TimetableEntryViewFactory.Create(e));
            }
        }
    }
}
