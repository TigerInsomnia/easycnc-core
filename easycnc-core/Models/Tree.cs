namespace easycnc_core.Models;

public class Tree
{
    public int Id { get; set; }
    public string Name { get; set; }=string.Empty;
    public int Pid { get; set; }
    public bool Leaf { get; set; }
    public List<Tree> Children { get; set; }=new List<Tree>();
}