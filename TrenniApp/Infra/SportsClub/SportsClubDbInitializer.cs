
using System;
using System.Collections.Generic;
using System.Linq;
using TrainingApp.Data.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public static class SportsClubDbInitializer
    {
        internal static ClientData albertUssisoo = new ClientData
        {
            Id = "37201143255",
            Name = "Albert Ussisoo",
            Email = "ussisoo.albert@net.ee",
            DateOfJoining = Convert.ToDateTime("04/03/2007")
        };

        internal static ClientData malleMaasikas = new ClientData
        {
            Id = "49003310713",
            Name = "Malle Maasikas",
            Email = "malle.maasikas@hotmail.com",
            DateOfJoining = Convert.ToDateTime("22/01/2018")
        };

        internal static ClientData erleMaido = new ClientData
        {
            Id = "49406160242",
            Name = "Erle Maido",
            Email = "maido.erle@gmail.com",
            DateOfJoining = Convert.ToDateTime("01/01/2020")
        };

        internal static ClientData janeliMutukas = new ClientData
        {
            Id = "49506160242",
            Name = "Janeli Mutukas",
            Email = "janzy123@gmail.com",
            DateOfJoining = Convert.ToDateTime("31/08/2019")
        };

        internal static ClientData tiinaLehis = new ClientData
        {
            Id = "60104271104",
            Name = "Tiina Lehis",
            Email = "tiinalehis@gmail.com",
            DateOfJoining = Convert.ToDateTime("23/12/2019")
        };

        internal static ClientData mariaKivi = new ClientData
        {
            Id = "49004170456",
            Name = "Maria Kivi",
            Email = "maria.kivi@ttu.ee",
            DateOfJoining = Convert.ToDateTime("05/09/2014")
        };

        internal static CoachData tiinaSirkel = new CoachData
        {
            Id = "tiinasirkel",
            Name = "Tiina Sirkel",
            Age = 25,
            Email = "t.sirkel@sportsclub.com",
            CoachCertificateNumber = "23908",
            HireDate = Convert.ToDateTime("02/09/2018"),
            Description = "Mingi kirjeldus"
        };

        internal static CoachData martinLeib = new CoachData
        {
            Id = "martinleib",
            Name = "Martin Leib",
            Age = 35,
            Email = "m.leib@sportsclub.com",
            CoachCertificateNumber = "00246",
            HireDate = Convert.ToDateTime("02/09/2018"),
            Description = "Mingi kirjeldus"
        };

        internal static CoachData marianneOts = new CoachData
        {
            Id = "marianneots",
            Name = "Marianne Ots",
            Age = 33,
            Email = "m.ots@sportsclub.com",
            HireDate = Convert.ToDateTime("22/05/2015"),
        };

        internal static CoachData marjuMurel = new CoachData
        {
            Id = "marjumurel",
            Name = "Marju Murel",
            Age = 27,
            Email = "m.murel@sportsclub.com",
            CoachCertificateNumber = "19686",
            HireDate = Convert.ToDateTime("03/03/2007"),
            Description = "Mingi kirjeldus"
        };

        internal static LocationData loc1 = new LocationData
        {
            Id = "J101",
            Name = "J101"
        };

        internal static LocationData loc2 = new LocationData
        {
            Id = "S123",
            Name = "S123"
        };

        internal static LocationData loc3 = new LocationData
        {
            Id = "S147",
            Name = "S147"
        };

        internal static LocationData loc4 = new LocationData
        {
            Id = "S200",
            Name = "S200"
        };

        internal static LocationData loc5 = new LocationData
        {
            Id = "S302",
            Name = "S302"
        };

        internal static LocationData loc6 = new LocationData
        {
            Id = "U001",
            Name = "U001"
        };

        internal static TrainingCategoryData dance = new TrainingCategoryData
        {
            Id = "tants",
            Name = "Tants"
        };

        internal static TrainingCategoryData gym = new TrainingCategoryData
        {
            Id = "jõusaal",
            Name = "Jõusaal"
        };

        internal static TrainingCategoryData bodyAndMind = new TrainingCategoryData
        {
            Id = "kehajameel",
            Name = "Keha ja meel"
        };

        internal static TrainingCategoryData strength = new TrainingCategoryData
        {
            Id = "jõud",
            Name = "Jõud"
        };

        internal static TrainingCategoryData endurance = new TrainingCategoryData
        {
            Id = "vastupidavus",
            Name = "Vastupidavus"
        };

        internal static TrainingTypeData group = new TrainingTypeData
        {
            Id = "grupp",
            Name = "Grupp"
        };

        internal static TrainingTypeData miniGroup = new TrainingTypeData
        {
            Id = "minigrupp",
            Name = "Mini grupp"
        };

        internal static TrainingTypeData personal = new TrainingTypeData
        {
            Id = "era",
            Name = "Era"
        };

        internal static TrainingData bodyjam = new TrainingData
        {
            Id = "bodyjam",
            Name = "BodyJam",
            Code = "BJAM",
            DurationInMinutes = 90,
            TrainingCategoryId = "tants",
            Description = "Les Mills kontsepttundide hulka kuuluv tantsutreening, mis põletab hästi kaloreid, " +
                          "hoiab keha vormis ja pakub igale tantsuharrastajale super elamuse. Viimased hitid ja " +
                          "popid tantsuliigutused ning parimad treenerid pakuvad Sulle tõelise elamuse! Tunni sisu " +
                          "püsib sama 3 kuud, mis võimaldab kõigil sammud ja liikumised selgeks saada."
        };

        internal static TrainingData yoga = new TrainingData
        {
            Id = "jooga",
            Name = "Jooga",
            Code = "JOGA",
            DurationInMinutes = 45,
            TrainingCategoryId = "kehajameel",
            Description = "Treening, kus lihasvastupidavuse arendamiseks õpitakse erinevaid jooga asendeid ehk asanaid. " +
                          "Tund aitab parandada füüsilist vastupidavust, arendada lihasjõudu ja painduvust ning korrigeerida rühti. " +
                          "Lisaks lihasjõudu nõudvatele asenditele annab tund suurepärase võimaluse saavutada tasakaal keha ja meele " +
                          "vahel ning vabaneda sisemistest pingetest ning stressist."
        };

        internal static TrainingData bodypump = new TrainingData
        {
            Id = "bodypump",
            Name = "BodyPump",
            Code = "BPUM",
            DurationInMinutes = 90,
            TrainingCategoryId = "jõud",
            Description = "Les Mills kontsepttundide hulka kuuluv lihasvastupidavustreening, kus harjutuste sooritamiseks" +
                          " (kükid, väljaasted, jõutõmbed, kätekõverdused jms) kasutatakse kange, kettaid, hantleid ja stepipinki. " +
                          "Treeningu jooksul saavad koormust kõik suuremad lihasgrupid. Kaasahaarava muusika saatel treenid nii jõudu " +
                          "kui ka lihasvastupidavust. Kuna tund on emotsionaalne ja kaasahaarav, siis sooritad endalegi märkamatult palju " +
                          "korduseid ning saavutad järjepidevuse korral aina paremaid tulemusi. Üks treeningprogramm kestab 3 kuud."
        };

        internal static TrainingData gymTraining = new TrainingData
        {
            Id = "jõusaal",
            Name = "Jõusaal",
            Code = "GYM1",
            DurationInMinutes = 60,
            TrainingCategoryId = "jõusaal",
            Description = "Spordiklubis on hästivarustatud jõusaal, kust leiate suurepärase valiku kardiomasinaid,  " +
                          "vabaraskuste ala, funktsionaalse ala ja venitusala. Seadmeparki kuuluvad enamuses Technogym seadmed " +
                          "ja vabaraskused, mis on kvaliteetsed ja kõrgelt tunnustatud kogu maailmas. Lisaks on valitud " +
                          "klubides olemas CrossTraining ja funktsionaalalad, kus saab teha efektiivseid kogu keha treeninguid " +
                          "ja kasutada paljusid erinevaid vahendeid."
        };

        internal static TimetableEntryData entry1 = new TimetableEntryData
        {
            TrainingId = "bodyjam",
            Date = Convert.ToDateTime("02/06/2020"),
            StartTime = Convert.ToDateTime("11:00"),
            EndTime = Convert.ToDateTime("12:30"),
            LocationId = "S123",
            CoachId = "tiinasirkel",
            TrainingTypeId = "grupp",
            TrainingLevel = TrainingLevel.Keskmine,
            Id = "0206202011bodyjam",
            Name = "BodyJam 02/06/2020 11:00-12:30 S123 grupitrenn Tiina Sirkel",
            MaxNumberOfParticipants = 30,
            Description = "Tund toimub inglise keeles"
        };

        internal static TimetableEntryData entry2 = new TimetableEntryData
        {
            TrainingId = "jõusaal",
            Date = Convert.ToDateTime("03/06/2020"),
            StartTime = Convert.ToDateTime("17:00"),
            EndTime = Convert.ToDateTime("18:00"),
            LocationId = "J101",
            CoachId = "martinleib",
            TrainingTypeId = "era",
            TrainingLevel = TrainingLevel.Määramata,
            Id = "0306202017jõusaal",
            Name = "Jõusaal 03/06/2020 17:00-18:00 J101 personaaltrenn Martin Leib",
            MaxNumberOfParticipants = 1,
        };

        internal static TimetableEntryData entry3 = new TimetableEntryData
        {
            TrainingId = "bodyjam",
            Date = Convert.ToDateTime("05/06/2020"),
            StartTime = Convert.ToDateTime("19:00"),
            EndTime = Convert.ToDateTime("20:30"),
            LocationId = "S200",
            CoachId = "tiinasirkel",
            TrainingTypeId = "grupp",
            TrainingLevel = TrainingLevel.Keskmine,
            Id = "0506202019bodyjam",
            Name = "BodyJam 05/06/2020 19:00-20:30 S200 grupitrenn Tiina Sirkel",
            MaxNumberOfParticipants = 30,
        };

        internal static ParticipantOfTrainingData albertBodyJam = new ParticipantOfTrainingData
        {
            ClientId = "37201143255",
            TimetableEntryId = "0206202011bodyjam",
            ValidFrom = Convert.ToDateTime("29/05/2020 17:46")
        };

        internal static ParticipantOfTrainingData albertGym = new ParticipantOfTrainingData
        {
            ClientId = "37201143255",
            TimetableEntryId = "0306202017jõusaal",
            ValidFrom = Convert.ToDateTime("30/05/2020 15:30")
        };

        internal static ParticipantOfTrainingData malleBodyJam = new ParticipantOfTrainingData
        {
            ClientId = "49003310713",
            TimetableEntryId = "0206202011bodyjam",
            ValidFrom = Convert.ToDateTime("31/05/2020 17:57")
        };

        internal static List<ClientData> Clients => new List<ClientData>
        {
            albertUssisoo, malleMaasikas, erleMaido, janeliMutukas, mariaKivi, tiinaLehis
        };

        internal static List<CoachData> Coaches => new List<CoachData>
        {
            tiinaSirkel, marianneOts, marjuMurel, martinLeib
        };

        internal static List<LocationData> Locations => new List<LocationData>
        {
            loc1, loc2, loc3, loc4, loc5, loc6
        };

        internal static List<TrainingCategoryData> Categories => new List<TrainingCategoryData>
        {
            dance, bodyAndMind, gym, strength, endurance
        };

        internal static List<TrainingTypeData> Types => new List<TrainingTypeData>
        {
            personal, miniGroup, @group
        };

        internal static List<TrainingData> Trainings => new List<TrainingData>
        {
            bodyjam, bodypump, yoga, gymTraining
        };

        internal static List<TimetableEntryData> TimetableEntries => new List<TimetableEntryData>
        {
            entry1, entry2, entry3
        };

        internal static List<ParticipantOfTrainingData> Participants => new List<ParticipantOfTrainingData>
        {
            albertBodyJam, albertGym, malleBodyJam
        };

        private static void InitializeClients(SportsClubDbContext db)
        {
            if (db.Clients.Count() != 0) return;
            db.Clients.AddRange(Clients);
            db.SaveChanges();
        }

        private static void InitializeCoaches(SportsClubDbContext db)
        {
            if (db.Coaches.Count() != 0) return;
            db.Coaches.AddRange(Coaches);
            db.SaveChanges();
        }

        private static void InitializeLocations(SportsClubDbContext db)
        {
            if (db.Locations.Count() != 0) return;
            db.Locations.AddRange(Locations);
            db.SaveChanges();
        }

        private static void InitializeTrainingCategories(SportsClubDbContext db)
        {
            if (db.TrainingCategories.Count() != 0) return;
            db.TrainingCategories.AddRange(Categories);
            db.SaveChanges();
        }

        private static void InitializeTrainingTypes(SportsClubDbContext db)
        {
            if (db.TrainingTypes.Count() != 0) return;
            db.TrainingTypes.AddRange(Types);
            db.SaveChanges();
        }

        private static void InitializeTrainings(SportsClubDbContext db)
        {
            if (db.Trainings.Count() != 0) return;
            db.Trainings.AddRange(Trainings);
            db.SaveChanges();
        }

        private static void InitializeTimetableEntries(SportsClubDbContext db)
        {
            if (db.TimetableEntries.Count() != 0) return;
            db.TimetableEntries.AddRange(TimetableEntries);
            db.SaveChanges();
        }

        private static void InitializeParticipantsOfTraining(SportsClubDbContext db)
        {
            if (db.ParticipantsOfTraining.Count() != 0) return;
            db.ParticipantsOfTraining.AddRange(Participants);
            db.SaveChanges();
        }

        public static void Initialize(SportsClubDbContext db)
        {
            InitializeClients(db);
            InitializeCoaches(db);
            InitializeLocations(db);
            InitializeTrainingCategories(db);
            InitializeTrainingTypes(db);
            InitializeTrainings(db);
            InitializeParticipantsOfTraining(db);
            InitializeTimetableEntries(db);
        }
    }
}
