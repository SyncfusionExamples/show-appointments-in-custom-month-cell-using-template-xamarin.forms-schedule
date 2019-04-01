using System;
using System.Collections;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
namespace CustomMonthCellTemplate
{
    public class MonthCellTemplateSelector : DataTemplateSelector
    {
        private DataTemplate MonthCellTemplate { get; set; }
        private DataTemplate MonthCellAppointmentTemplate { get; set; }
        public MonthCellTemplateSelector()
        {
            MonthCellTemplate = new DataTemplate(typeof(MonthCellTemplate));
            MonthCellAppointmentTemplate = new DataTemplate(typeof(MonthCellAppointmentTemplate));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var schedule = container as SfSchedule;
            if(schedule != null)
            {
                var appointments = (IList)(item as MonthCellItem).Appointments;
                if (appointments != null && appointments.Count > 0)
                    return MonthCellAppointmentTemplate;
                else
                    return MonthCellTemplate;
            }
            return null;
        }
    }
}
