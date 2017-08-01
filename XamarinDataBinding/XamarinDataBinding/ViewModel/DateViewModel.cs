using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamarinDataBinding
{
    public class DateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double minimumDuration;
        public double MinimumDuration
        {
            get { return minimumDuration; }
            set
            {
                if (minimumDuration != value)
                {
                    minimumDuration = value;

                    if (PropertyChanged != null)
                    {
                        OnPropertyChanged("MinimumDuration");
                    }
                }
            }
        }

        private double maximumDuration;
        public double MaximumDuration
        {
            get { return maximumDuration; }
            set
            {
                if (maximumDuration != value)
                {
                    maximumDuration = value;

                    if (PropertyChanged != null)
                    {
                        OnPropertyChanged("MaximumDuration");
                    }
                }
            }
        }

        private DateTime approvedApplyDate;
        public DateTime ApprovedApplyDate
        {
            get { return approvedApplyDate; }
            set
            {
                if (approvedApplyDate != value)
                {
                    approvedApplyDate = value;

                    if (PropertyChanged != null)
                    {
                        OnPropertyChanged("ApprovedApproveDate");
                    }
                }
            }
        }

        private DateTime approvedApproveDate;
        public DateTime ApprovedApproveDate
        {
            get { return approvedApproveDate; }
            set
            {
                if (approvedApproveDate != value)
                {
                    approvedApproveDate = value;

                    if (PropertyChanged != null)
                    {
                        OnPropertyChanged("ApprovedApproveDate");
                    }
                }
            }
        }

        private DateTime waitingApplyDate;
        public DateTime WaitingApplyDate
        {
            get { return waitingApplyDate; }
            set
            {
                if (waitingApplyDate != value)
                {
                    waitingApplyDate = value;

                    if (PropertyChanged != null)
                    {
                        OnPropertyChanged("WaitingApplyDate");
                    }
                }
            }
        }

        private DateTime waitingApproveDate;
        public DateTime WaitingApproveDate
        {
            get { return waitingApproveDate; }
            set
            {
                if (waitingApproveDate != value)
                {
                    waitingApproveDate = value;

                    if (PropertyChanged != null)
                    {
                        OnPropertyChanged("WaitingApproveDate");
                    }
                }
            }
        }

        private int duration;
        public int Duration
        {
            get { return duration; }
            set
            {
                if (duration != value)
                {
                    duration = value;

                    if (PropertyChanged != null)
                    {
                        OnPropertyChanged("Duration");
                    }
                }
            }
        }

        public DateViewModel()
        {
            minimumDuration = 1;
            maximumDuration = 100;
            approvedApplyDate = DateTime.Now.AddDays(-50);
            approvedApproveDate = DateTime.Now;

            waitingApplyDate = new DateTime(2017, 7, 11);
            Compute();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                if (propertyName != "WaitingApproveDate" && propertyName != "Duration")
                {
                    Compute();
                }

                if (  propertyName == "Duration")
                {
                    WaitingApproveDate = waitingApplyDate.AddDays(Duration);
 
                    PropertyChanged(this, new PropertyChangedEventArgs("WaitingApproveDate"));
                }

                    PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Compute()
        {
            TimeSpan ts = approvedApproveDate - approvedApplyDate;
            Duration = ts.Days;
            WaitingApproveDate = waitingApplyDate.AddDays(ts.TotalDays);
        }
    }
}
