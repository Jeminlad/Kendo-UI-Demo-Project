using MVC.Models;

namespace KendoDemo.Repositories.Interface;

public interface IContactInterface
{
    Task<List<t_Contact>> GetAll();
    Task<List<t_Contact>> GetAllByUser(string userid);

    Task<t_Contact> GetOne(string contactid);

    Task<int> Add(t_Contact contactData);

    Task<int> Update(t_Contact contactData);

    Task<int> Delete(string contactid);


    #region Kendo UI Methods

    List<t_Contact> Create();
    t_Contact GetOne(int id);
    void Insert(t_Contact data);
    void Delete(t_Contact data);
    Task<List<vm_Contact>> GetAllWithUserName();
    
    #endregion
}