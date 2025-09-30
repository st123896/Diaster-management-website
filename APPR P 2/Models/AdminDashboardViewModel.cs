

    // AdminDashboardViewModel.cs
    using System.Collections.Generic;

    namespace APPR_P_2.Models
    {
        public class AdminDashboardViewModel
        {
            public int TotalUsers { get; set; }
            public int TotalDonations { get; set; }
            public int TotalVolunteers { get; set; }
            public int TotalIncidents { get; set; }
            public List<ApplicationUser> RecentUsers { get; set; }
            public List<Donation> RecentDonations { get; set; }
        }
    }

