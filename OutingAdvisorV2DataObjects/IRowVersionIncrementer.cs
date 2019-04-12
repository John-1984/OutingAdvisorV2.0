using System;
namespace OutingAdvisorV2DataObjects
{
    public interface IRowVersionIncrementer
    {
        void OnSavingChanges();
    }
}
