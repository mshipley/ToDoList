﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoList
{
    public class CommandProxy:ICommand
    {
      
            Action _TargetExecuteMethod;
            Func<bool> _TargetCanExecuteMethod;

            public CommandProxy(Action executeMethod)
            {
                _TargetExecuteMethod = executeMethod;
            }

            public CommandProxy(Action executeMethod, Func<bool> canExecuteMethod)
            {
                _TargetExecuteMethod = executeMethod;
                _TargetCanExecuteMethod = canExecuteMethod;
            }

            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
           

            bool ICommand.CanExecute(object parameter)
            {
                if (_TargetCanExecuteMethod != null)
                {
                    return _TargetCanExecuteMethod();
                }
                if (_TargetExecuteMethod != null)
                {
                    return true;
                }
                return false;
            }

            public event EventHandler CanExecuteChanged = delegate { };

            void ICommand.Execute(object parameter)
            {
                if (_TargetExecuteMethod != null)
                {
                    _TargetExecuteMethod();
                }
            }
           
        }

        public class CommandProxy<T> : ICommand
        {
            Action<T> _TargetExecuteMethod;
            Func<T, bool> _TargetCanExecuteMethod;

            public CommandProxy(Action<T> executeMethod)
            {
                _TargetExecuteMethod = executeMethod;
            }

            public CommandProxy(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
            {
                _TargetExecuteMethod = executeMethod;
                _TargetCanExecuteMethod = canExecuteMethod;
            }


            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
            #region ICommand Members

            bool ICommand.CanExecute(object parameter)
            {
                if (_TargetCanExecuteMethod != null)
                {
                    T tparm = (T)parameter;
                    return _TargetCanExecuteMethod(tparm);
                }
                if (_TargetExecuteMethod != null)
                {
                    return true;
                }
                return false;
            }

            public event EventHandler CanExecuteChanged = delegate { };

            void ICommand.Execute(object parameter)
            {
                if (_TargetExecuteMethod != null)
                {
                    _TargetExecuteMethod((T)parameter);
                }
            }
            #endregion
        }
    }

