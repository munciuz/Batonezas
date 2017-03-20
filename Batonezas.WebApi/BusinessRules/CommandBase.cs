using System.Collections.Generic;
using System.Transactions;
using Batonezas.WebApi.Infrastructure;

namespace Batonezas.WebApi.BusinessRules
{
    public abstract class CommandBase : ICommand
    {
        protected ICollection<ErrorInfo> Errors { get; set; }

        protected CommandBase()
        {
            Errors = new List<ErrorInfo>();
        }

        public void AddError(string errorMessage)
        {
            AddError(string.Empty, errorMessage);
        }

        public void AddError(string propertyName, string errorMessage)
        {
            Errors.Add(new ErrorInfo(propertyName, errorMessage));
        }

        public void AddRequiredFieldError(string propertyName, string fieldTitle)
        {
            var errorMessage = $"Field {fieldTitle} is required.";
            Errors.Add(new ErrorInfo(propertyName, errorMessage));
        }

        public void AddError(ErrorInfo errorInfo)
        {
            Errors.Add(errorInfo);
        }

        public void AddErrors(ICollection<ErrorInfo> errorInfos)
        {
            if (errorInfos != null && errorInfos.Count > 0)
            {
                foreach (var errorInfo in errorInfos)
                {
                    Errors.Add(errorInfo);
                }
            }
        }

        public virtual void Execute()
        {
            using (var transaction = new TransactionScope())
            {
                if (!Validate())
                    throw new RulesException(Errors);

                ExecuteCommand();
                transaction.Complete();
                OnExecuted();
            }
        }

        protected abstract void ExecuteCommand();

        public virtual void OnExecuted()
        {
        }

        protected virtual bool Validate()
        {
            return Errors.Count == 0;
        }
    }
}