using System.Globalization;

namespace TrainingApp.Aids.Regions {

    public static class SystemCultureInfo {
        public static CultureInfo[] GetSpecific() {
            return GetCultures(CultureTypes.SpecificCultures);
        }

        public static CultureInfo[] GetCultures(CultureTypes types) {
            return Methods.Safe.Run(() => CultureInfo.GetCultures(types),
                new CultureInfo[0]);
        }

        public static RegionInfo ToRegionInfo(CultureInfo info) {
            return info is null
                ? null
                : Methods.Safe.Run(() => new RegionInfo(info.LCID), null);
        }
    }

}







