namespace Homework.Models.ViewModels
{
    public class ServicesViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }
}
