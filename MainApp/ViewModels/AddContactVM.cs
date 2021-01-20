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

        private IStorage storage;

        public static int Count = 100;
        private bool unFavoriteProp;
        private bool favoriteProp;
        private string firstNameProp;
        private string lastNameProp;
        private string emailAdressProp;
        private string jobProp;
        private string photoProp;
        private string phoneNumberProp;

        [Required]
        public string FirstNameProp
        {
            get => firstNameProp;
            set
            {
                firstNameProp = value;
                AddButtonCommand.RaiseCanExecuteChanged();
            }
        }

        [Required]
        public string LastNameProp
        {
            get => lastNameProp;
            set
            {
                lastNameProp = value;
                AddButtonCommand.RaiseCanExecuteChanged();
            }
        }

        [Required]
        [Phone]
        public string PhoneNumberProp { get => phoneNumberProp; 
            set 
            {
                Set(ref phoneNumberProp, value); 
                AddButtonCommand.RaiseCanExecuteChanged();
            } 
        }
        [Required]
        [EmailAddress]
        public string EmailAdressProp
        {
            get => emailAdressProp;
            set
            {
                emailAdressProp = value;
                AddButtonCommand.RaiseCanExecuteChanged();
            }
        }

        public string PhotoProp
        {
            get => photoProp;
            set
            {
                Set(ref photoProp, value);
            }
        }
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
                Set(ref unFavoriteProp, value);
            }
        }

        [Required]
        public string JobProp
        {
            get => jobProp;
            set
            {
                Set(ref jobProp, value);
                AddButtonCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand AddButtonCommand => addButtonCommand ??= new RelayCommand(() => Add(),
         () => this["FirstNameProp"] == string.Empty &&
               this["LastNameProp"] == string.Empty &&
               this["PhoneNumberProp"] == string.Empty &&
               this["FavoriteProp"] == string.Empty &&
               this["JobProp"] == string.Empty 

          );

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
