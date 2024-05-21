namespace DataAccessLibrary;

public class ChangeModel
{
    public int ChanID { get; set; }
    public CallerModel Caller { get; set; }
    public string BriefDescription { get; set; }
    public SubCategoryModel SubCategory { get; set; }
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime ImplementedTime { get; set; }
    public string Status { get; set; }
    public bool ApprovedByApprover { get; set; }
    public OperatorModel Operator { get; set; }
    public bool IsTemplate { get; set; }
    public bool NeedApproval { get; set; }
    public List<CommentModel> Comments { get; set; } = new List<CommentModel>();

    public ChangeModel()
    {
        Caller = new CallerModel();
        SubCategory = new SubCategoryModel();
        StartTime = DateTime.Now;
        ImplementedTime = DateTime.Now;
        Operator = new OperatorModel();
    }
}
