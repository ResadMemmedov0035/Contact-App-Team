using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MainApp.Models;
using MainApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MainApp.ViewModels
{
    class AddContactVM : ViewModelBase, IDataErrorInfo
    {
        private RelayCommand addButtonCommand;

        IStorage storage;

        public static int Count = 100;
        private bool unFavoriteProp;
        private bool favoriteProp;

        [Required]
        public string FirstNameProp { get; set; }

        [Required]
        public string LastNameProp { get; set; }

        [Required]
        [Phone]
        public string PhoneNumberProp { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAdressProp { get; set; }

        public string PhotoProp { get; set; }

        public bool FavoriteProp 
        { 
            get => favoriteProp; 
            set 
            {

                if (UnFavoriteProp) UnFavoriteProp = false;
                Set(ref favoriteProp, value);
            } 
        }
        public bool UnFavoriteProp
        {
            get => unFavoriteProp;
            set 
            {
                if (FavoriteProp) FavoriteProp = false;
                Set(ref unFavoriteProp,value); 
            }
        }

        [Required]
        public string JobProp { get; set; }

        public RelayCommand AddButtonCommand => addButtonCommand ??= new RelayCommand(() => Add());

        public AddContactVM(IStorage storage)
        {
            this.storage = storage;
        }
        public void Add()
        {
            storage.Add(new Contact()
            {
                FirstName = FirstNameProp,
                LastName = LastNameProp,
                ID = ++Count,
                PhotoURL = PhotoProp,
                PhoneNumber = PhoneNumberProp,
                EmailAdress = EmailAdressProp,
                Job = JobProp,
                Favorite = FavoriteProp
            });
            App.Container.GetInstance<ContactDetailsVM>().IncreaseCount();
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                
                var context = new ValidationContext(this);
                var results = new List<ValidationResult>();
                var IsValid = Validator.TryValidateObject(this, context, results, true);
                if (IsValid)
                    return string.Empty;

                var result = results.FirstOrDefault(x => x.MemberNames.Contains(columnName));

                if (result is null)
                    return string.Empty;

                return result.ErrorMessage;
            }
        }
    }
}
