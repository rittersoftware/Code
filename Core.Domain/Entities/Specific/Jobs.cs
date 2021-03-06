﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Core.Domain.Annotations;

namespace Core.Domain.Entities.Specific
{
    [Table("Jobs")]
    public class Jobs : INotifyPropertyChanged
    {
        [Key] public virtual Guid JobId { get; set; } = Guid.NewGuid();
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual JobStatus JobStatus { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
