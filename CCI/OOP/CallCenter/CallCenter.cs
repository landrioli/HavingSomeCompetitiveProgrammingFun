using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.OOP.CallCenter
{
    public class CallCenter
    {
        public class CallRequest
        {
            public string TelefoneNumber { get; set; }
            public string CallerName { get; set; }
        }

        public interface ICallService
        {
            void ProcessCall(CallRequest request);
        }
        public class CallService
        {
            private IEmployee[] _employees;

            public CallService(IEmployee[] employees)
            {
                _employees = employees;
            }

            public void ProcessCall(CallRequest request)
            {
                foreach (var employee in _employees)
                {
                    if (employee.CanHandleTheCall())
                    {
                        employee.ProcessCall(request);
                    }                    
                }
            }
        }


        public interface IEmployee
        {
            bool CanHandleTheCall();
            void SetAvailability(bool isAvailabe);
            void ProcessCall(CallRequest request);
        }

        public abstract class EmployeeBase {
            protected bool isAvailable;
            protected string name;

            public void SetAvailability(bool isAvailabe)
            {
                isAvailable = isAvailabe;
            }
        }

        public class Respondent : EmployeeBase, IEmployee
        {
            private bool _isAvailable;

            public Respondent(bool isAvailable)
            {
                _isAvailable = isAvailable;
            }

            public bool CanHandleTheCall()
            {
                return _isAvailable;
            }

            public void ProcessCall(CallRequest request)
            {
                //Some logic
            }

        }

        public class Manager : EmployeeBase, IEmployee
        {
            private bool _isAvailable;

            public Manager(bool isAvailable)
            {
                _isAvailable = isAvailable;
            }

            public bool CanHandleTheCall()
            {
                return _isAvailable;
            }

            public void ProcessCall(CallRequest request)
            {
                //Some logic
            }
        }

        public class Director : EmployeeBase, IEmployee
        {
            private bool _isAvailable;

            public Director(bool isAvailable)
            {
                _isAvailable = isAvailable;
            }

            public bool CanHandleTheCall()
            {
                return _isAvailable;
            }

            public void ProcessCall(CallRequest request)
            {
                //Some logic
            }
        }
    }
}
