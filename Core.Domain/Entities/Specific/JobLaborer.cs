using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Core.Domain.Annotations;
using Core.Domain.Entities.Security;

namespace Core.Domain.Entities.Specific
{
    [Table("JobLaborer")]
    public class JobLaborer : INotifyPropertyChanged
    {
        [Key] public virtual Guid JobLaborerId { get; set; } = Guid.NewGuid();
        public virtual List<User> Users { get; set; }
        public virtual List<Jobs> Jobs { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
