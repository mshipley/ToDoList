using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using System.Windows.Media;
using ToDoList.Abstract;
using ToDoList.Data.Entities;
using ToDoList.Repositories;
using ToDoList.Repositories.Abstract;

namespace ToDoList.Overview
{
    public class ToDoItemViewModel : ObservableObject, IToDoItemViewModel
    {

        private int _id;
        private string _task;
        private DateTime _deadline;
        private bool _completed;
        private string _moreDetails;
        private Timer _hasExpiredTimer;
        private IToDoItemRepository _toDoItemRepository;

        public ToDoItemViewModel(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
            UpdateCommand = new CommandProxy(Update);
            this.Deadline = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }
        public ToDoItemViewModel() : this(ContainerHelper.Container.GetInstance<IToDoItemRepository>())
        {

        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChangedEvent("Id");
            }
        }

        public string Task
        {
            get { return _task; }
            set
            {
                _task = value;
                RaisePropertyChangedEvent("Task");
            }
        }

        public bool HasExpired => Deadline < DateTime.Now;



        public System.Windows.Media.Brush BackgroundColor
        {
            get
            {
                if (!HasExpired && _hasExpiredTimer == null)
                {
                    _hasExpiredTimer = new Timer { Interval = (Deadline-DateTime.Now).Seconds};
                    _hasExpiredTimer.Elapsed += CheckExpired;
                    _hasExpiredTimer.Start();
                }

                return HasExpired ? new SolidColorBrush(Colors.LightSalmon) : new SolidColorBrush(Colors.Transparent);
            }

        }
        public void CheckExpired(object sender, EventArgs e)
        {
            if (HasExpired)
            {
                _hasExpiredTimer.Stop();
                RaisePropertyChangedEvent("BackgroundColor");
            }
        }

        public DateTime Deadline
        {
            get { return _deadline; }
            set
            {
                _deadline = value;
                RaisePropertyChangedEvent("Deadline");
            }
        }

        public bool Completed
        {
            get { return _completed; }
            set
            {
                _completed = value;
                RaisePropertyChangedEvent("Completed");
            }
        }

        public string MoreDetails
        {
            get { return _moreDetails; }
            set
            {
                _moreDetails = value;
                RaisePropertyChangedEvent("MoreDetails");
            }
        }

        public CommandProxy UpdateCommand { get; set; }

        private void Update()
        {
            _toDoItemRepository.Update(this.Id, i =>
            {
                i.Deadline = this.Deadline;
                i.Completed = this.Completed;
                i.MoreDetails = this.MoreDetails;
                i.Task = this.Task;
            });
        }





    }
}
