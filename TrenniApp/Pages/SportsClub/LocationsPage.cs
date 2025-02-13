﻿using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public abstract class LocationsPage : CommonPage<ILocationsRepository, Location, LocationView, LocationData>
    {

        protected internal LocationsPage(ILocationsRepository locationsRepository) : base(locationsRepository)
        {
            PageTitle = "Asukohad";
        }

        public override string ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/SportsClub/Locations";

        protected internal override Location ToObject(LocationView view)
        {
            return LocationViewFactory.Create(view);
        }

        protected internal override LocationView ToView(Location obj)
        {
            return LocationViewFactory.Create(obj);
        }
    }
}

