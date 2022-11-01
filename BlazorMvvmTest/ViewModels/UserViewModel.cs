using BlazorMvvmTest.Event;
using BlazorMvvmTest.Models;
using BlazorMvvmTest.Views;
using Prism.Commands;
using Prism.Events;

namespace BlazorMvvmTest.ViewModels
{
    public class UserViewModel
    {
        private readonly IEventAggregator _ea;

        public DelegateCommand UserCommand { get; set; }

        public UserViewModel(IEventAggregator ea)
        {
            _ea = ea;
            UserCommand = new DelegateCommand(GetYsers);
            GetYsers();
        }

        public List<User>? Users { get; set; }

        public void GetYsers()
        {
            Users = new List<User>()
            {
                new User() {Id=1, Name="홍길동", Email="abc@google.com", DeptName="자재과"},
                new User() {Id=2, Name="이순신", Email="edf@google.com", DeptName="총무과"},
                new User() {Id=3, Name="강감찬", Email="kbs@google.com", DeptName="비서실"},
            };
        }

        public void Publish()
        { 
            _ea.GetEvent<UserEvent>().Publish("Is worked");
        }

        //https://www.youtube.com/watch?v=McwHoSuhudw&t=2519s&ab_channel=BrianLagunas
    }
}
