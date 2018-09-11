using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Core.Domain.Annotations;

namespace Core.Domain.Entities.Specific
{
    [Table("JobStatus")]
    public class JobStatus : INotifyPropertyChanged
    {
        [Key] public virtual Guid JobStatusId { get; set; } = Guid.NewGuid();
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}