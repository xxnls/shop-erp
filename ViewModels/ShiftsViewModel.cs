using Microsoft.EntityFrameworkCore;
using ShopERP.Models;
using ShopERP.Models.Contexts;
using ShopERP.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShopERP.ViewModels
{
    public class ShiftsViewModel : BaseObjectViewModel<Shift>
    {
        #region Properties and Fields
        private TimeOnly _shiftStartTime;
        public TimeOnly ShiftStartTime
        {
            get { return _shiftStartTime; }
            set
            {
                if (_shiftStartTime != value)
                {
                    _shiftStartTime = value;
                    OnPropertyChanged(() => ShiftStartTime);
                }
            }
        }

        private TimeOnly _shiftEndTime;
        public TimeOnly ShiftEndTime
        {
            get { return _shiftEndTime; }
            set
            {
                if (_shiftEndTime != value)
                {
                    _shiftEndTime = value;
                    OnPropertyChanged(() => ShiftEndTime);
                }
            }
        }

        private double _shiftTotalHours;
        public double ShiftTotalHours
        {
            get { return _shiftTotalHours; }
            set
            {
                if (_shiftTotalHours != value)
                {
                    _shiftTotalHours = value;
                    OnPropertyChanged(() => ShiftTotalHours);
                }
            }
        }

        public override string this[string columnName] => throw new NotImplementedException();
        #endregion

        public ShiftsViewModel() : base("Shifts")
        {
        }

        #region Methods
        public override void Save()
        {
            using (var dbContext = new DatabaseContext())
            {
                var shift = new Shift
                {
                    ShiftStartTime = ShiftStartTime,
                    ShiftEndTime = ShiftEndTime,
                    ShiftTotalHours = ShiftTotalHours,
                    DateCreated = DateTime.Now
                };
                dbContext.Shifts.Add(shift);
                dbContext.SaveChanges();
            }
            Refresh();
        }

        public override void Delete()
        {
            if (SelectedModel != null)
            {
                using (var dbContext = new DatabaseContext())
                {
                    var shift = dbContext.Shifts.Find(SelectedModel.ShiftId);
                    shift.DateDeleted = DateTime.Now;
                    dbContext.SaveChanges();
                }
                Refresh();
            }
        }

        public override void Edit()
        {
            if (SelectedModel != null)
            {
                using (var dbContext = new DatabaseContext())
                {
                    var shift = dbContext.Shifts.Find(SelectedModel.ShiftId);
                    shift.ShiftStartTime = SelectedModel.ShiftStartTime;
                    shift.ShiftEndTime = SelectedModel.ShiftEndTime;
                    shift.ShiftTotalHours = SelectedModel.ShiftTotalHours;
                    shift.DateEdited = DateTime.Now;
                    dbContext.SaveChanges();
                    SelectedModel = null;
                }
                Refresh();
            }
        }

        public override IEnumerable<Shift> GetModels()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Shifts.Where(address => address.DateDeleted == null)
                                       .ToList();
            }
        }

        public override void Filter()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
