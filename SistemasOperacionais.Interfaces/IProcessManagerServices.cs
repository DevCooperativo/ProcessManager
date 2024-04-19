namespace SistemasOperacionais.Interfaces;
public interface IProcessManagerServices
{
    public bool GetIsSJF();
    public void SetIsSJF(bool value);
    public void GetProcessList();
    public void AddProcessToProcessList(IProcessServices process);
}
