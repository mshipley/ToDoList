
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using ToDoList.Abstract;
using ToDoList.Data;
using ToDoList.Data.Entities;
using ToDoList.Factories;
using ToDoList.Repositories;
using ToDoList.Repositories.Abstract;

namespace ToDoList.Overview
{
    public class OverviewViewModel<T>:ObservableObject where T: IToDoItemViewModel
    {
        private IToDoItemRepository _toDoItemRepository;
        private IFactory<ToDoItem, T> _toDoItemViewModelFactory;
        private T _selecteDoItemViewModel;

        public OverviewViewModel(IToDoItemRepository toDoItemRepository, IFactory<ToDoItem, T> toDoItemViewModelFactory)
        {
            if (DesignerProperties.GetIsInDesignMode(
            new System.Windows.DependencyObject())) return;

            _toDoItemRepository = toDoItemRepository;
            _toDoItemViewModelFactory = toDoItemViewModelFactory;
          
            this.refreshToDoItems();
            this.DeleteCommand = new CommandProxy<int>(Delete);
            this.CreateCommand = new CommandProxy<IToDoItemViewModel>(Create);

        }

        public T SelecteDoItemViewModel
        {
            get { return _selecteDoItemViewModel; }
            set
            {
                _selecteDoItemViewModel = value;
                RaisePropertyChangedEvent("SelecteDoItemViewModel");
            }
        }

        private void refreshToDoItems()
        {
       
            this.ToDoItems = new ObservableCollection<T>(_toDoItemRepository.Get().Select(_toDoItemViewModelFactory.Produce()));
            RaisePropertyChangedEvent("ToDoItems");
        }
        public ObservableCollection<T> ToDoItems { get; set; }

        public CommandProxy<int> DeleteCommand { get; private set; }
        public CommandProxy<IToDoItemViewModel> CreateCommand { get; private set; }

        private void Delete(int key)
        {
            _toDoItemRepository.Delete(key);
            var item = this.ToDoItems.FirstOrDefault(i => i.Id == key);
            this.ToDoItems.Remove(item);
        }

        private void Create(IToDoItemViewModel newItem)
        {
           

            _toDoItemRepository.Create(new ToDoItem()
            {
                Task = newItem.Task,
                Deadline = newItem.Deadline,
                MoreDetails = newItem.MoreDetails,
                Completed = false
            });

            this.refreshToDoItems();

            newItem.Task = "";
            newItem.Deadline=DateTime.Now;
            newItem.MoreDetails = "";
           

        }

    }
}
