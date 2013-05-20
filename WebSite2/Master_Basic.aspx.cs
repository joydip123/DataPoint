using System;
using System.Collections.Specialized;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
//using ServiceReference1;
using ServiceReference3;


public partial class Master_Basic : System.Web.UI.Page
{
    static int j = 0, k = 0;
    //static int i = 0;
    TextBox tb, tb1;
    
    //ServiceReference1.Service1Client objServiceClientobjService = new ServiceReference1.Service1Client();
    ServiceReference3.Service1Client objServiceClientobjService = new ServiceReference3.Service1Client();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
            SetInitialRow();
            SetInitialRow1();
            bindtreeview();
        }
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        BasicDetails BasicInfo = new BasicDetails();

        BasicInfo.basicid = TextBoxId.Text;

        BasicInfo.name = TextBoxName.Text;

        BasicInfo.description = TextBoxDescription.Text;

        BasicInfo.expire_t = TextBoxTime.Text;

        BasicInfo.expire_s = TextBoxSize.Text;
        
        //BasicInfo.Read = TextBoxRead.Text;

        //BasicInfo.Write = TextBoxWrite.Text;
        //int cnt = 0;
        int rowIndex = 0;
        StringCollection sc = new StringCollection();
        string rs = "";

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            //DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    
                    TextBox box1 = (TextBox)gv_read.Rows[rowIndex].Cells[0].FindControl("TextBox1");

                    sc.Add(box1.Text);
                  
                   
                    ////////////////////////////////////////////////////////////////////////////////
                    rs = rs + "," + box1.Text;
                   
                  
                    
                  
                    rowIndex++;

                }
                
               //cnt=dtCurrentTable.Rows.Count;
               
            }
        }
        rs = rs.TrimStart(','); 
        int rowIndex1 = 0;
        StringCollection sc1 = new StringCollection();
        string wrt = "";
        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dtCurrentTable1 = (DataTable)ViewState["CurrentTable1"];
            //DataRow drCurrentRow1 = null;
            if (dtCurrentTable1.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable1.Rows.Count; i++)
                {
                    //extract the TextBox values

                    TextBox box2 = (TextBox)gv_write.Rows[rowIndex1].Cells[0].FindControl("TextBox2");

                    sc1.Add(box2.Text);


                    ////////////////////////////////////////////////////////////////////////////////
                    wrt = wrt + "," + box2.Text;




                    rowIndex1++;

                }

                //cnt=dtCurrentTable.Rows.Count;

            }
        }
        wrt = wrt.TrimStart(','); 
        
        string result = objServiceClientobjService.InsertBasicDetails(BasicInfo,rs,wrt);

       LabelMessage.Text = result;
       TextBoxId.Text = "";
       TextBoxDescription.Text="";
       TextBoxSize.Text = "";
       TextBoxName.Text = "";
       TextBoxTime.Text = "";
       SetInitialRow();
       SetInitialRow1();
        LoadGrid();

    }
    protected void GV_Basic_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GV_Basic.SelectedRow;
        TextBoxId.Text = row.Cells[1].Text;
        string Id = row.Cells[1].Text;
        TextBoxDescription.Text = row.Cells[2].Text;
        TextBoxSize.Text = row.Cells[3].Text;
        TextBoxTime.Text = row.Cells[4].Text;
        TextBoxName.Text = row.Cells[5].Text;

        BasicDetails obj = new BasicDetails();
        objServiceClientobjService.getBasicInfoById(Id);
        //gv_read.DataSource = objServiceClientobjService.getBasicInfoById(Id);
        //gv_read.DataBind();
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        //BasicDetails objBasic = new BasicDetails();
        //objBasic.BasicId = TextBoxId.Text;
        //objBasic.Name = TextBoxName.Text;
        //objBasic.Description = TextBoxDescription.Text;
        //objBasic.Expire_s = TextBoxSize.Text;
        //objBasic.Expire_t = TextBoxTime.Text;
        ////objBasic.Read = TextBoxRead.Text;
        ////objBasic.Write = TextBoxWrite.Text;
        ////objServiceClientobjService.GetUpdatedBasic(objBasic);

        //LoadGrid();
        BasicDetails BasicInfo = new BasicDetails();

        BasicInfo.basicid = TextBoxId.Text;

        BasicInfo.name = TextBoxName.Text;

        BasicInfo.description = TextBoxDescription.Text;

        BasicInfo.expire_t = TextBoxTime.Text;

        BasicInfo.expire_s = TextBoxSize.Text;

        //BasicInfo.Read = TextBoxRead.Text;

        //BasicInfo.Write = TextBoxWrite.Text;
        //int cnt = 0;
        int rowIndex = 0;
        StringCollection sc = new StringCollection();
        string Editrd = "";

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            //DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values

                    TextBox box1 = (TextBox)gv_read.Rows[rowIndex].Cells[0].FindControl("TextBox1");

                    sc.Add(box1.Text);


                    ////////////////////////////////////////////////////////////////////////////////
                    Editrd = Editrd + "," + box1.Text;




                    rowIndex++;

                }

                //cnt=dtCurrentTable.Rows.Count;

            }
        }
        Editrd = Editrd.TrimStart(',');
        int rowIndex1 = 0;
        StringCollection sc1 = new StringCollection();
        string Editwrt = "";
        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dtCurrentTable1 = (DataTable)ViewState["CurrentTable1"];
            //DataRow drCurrentRow1 = null;
            if (dtCurrentTable1.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable1.Rows.Count; i++)
                {
                    //extract the TextBox values

                    TextBox box2 = (TextBox)gv_write.Rows[rowIndex1].Cells[0].FindControl("TextBox2");

                    sc1.Add(box2.Text);


                    ////////////////////////////////////////////////////////////////////////////////
                    Editwrt = Editwrt + "," + box2.Text;




                    rowIndex1++;

                }

                //cnt=dtCurrentTable.Rows.Count;

            }
        }
        Editwrt = Editwrt.TrimStart(',');

        string result = objServiceClientobjService.InsertBasicDetails(BasicInfo, Editrd, Editwrt);

        LabelMessage.Text = result;
        TextBoxId.Text = "";
        TextBoxDescription.Text = "";
        TextBoxSize.Text = "";
        TextBoxName.Text = "";
        TextBoxTime.Text = "";
        SetInitialRow();
        SetInitialRow1();
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        objServiceClientobjService.DeleteBasicInfo(TextBoxId.Text);
        LoadGrid();
    }
    void LoadGrid()
    {
        GV_Basic.DataSource = objServiceClientobjService.getAll();
        GV_Basic.DataBind();
        //TreeView1.DataSource = objServiceClientobjService.getAll();
        //TreeView1.DataBind();
    }



    protected void img_addRead_Click(object sender, ImageClickEventArgs e)
        {
        
        j++;
       
            //MultiView1.ActiveViewIndex = 0;
        
        TableRow trow;
        TableCell tcell1;
        for (int i = 0; i < j; i++)
        {
            trow = new TableRow();
            tcell1 = new TableCell();
            tb=new TextBox();
            //tb.ID = "txt_add" + j.ToString();
            tcell1.Controls.Add(tb);
            trow.Cells.Add(tcell1);
            mytbl.Rows.Add(trow);

        }
        tb.ID = "txt_read" + j.ToString();
    }
    protected void img_addWrite_Click(object sender, ImageClickEventArgs e)
    {
        k++;

        //MultiView2.ActiveViewIndex = 0;
        //MultiView1.ActiveViewIndex = 0;

        TableRow trow1;
        TableCell tcell;
        for (int n = 0; n < k; n++)
        {
            trow1 = new TableRow();
            tcell = new TableCell();
            tb1 = new TextBox();
            //tb.ID = "txt_add" + j.ToString();
            tcell.Controls.Add(tb1);
            trow1.Cells.Add(tcell);
            mytbl1.Rows.Add(trow1);

        }
        tb1.ID = "txt_write" + k.ToString();
    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        

        dr = dt.NewRow();
        
        dr["Column1"] = string.Empty;
       

        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        gv_read.DataSource = dt;
        gv_read.DataBind();
    }
    private void SetInitialRow1()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("Column1", typeof(string)));


        dr = dt.NewRow();

        dr["Column1"] = string.Empty;


        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable1"] = dt;

        gv_write.DataSource = dt;
        gv_write.DataBind();
    }
    private void AddNewRowToGrid()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= gv_read.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)gv_read.Rows[rowIndex].Cells[0].FindControl("TextBox1");
                    drCurrentRow = dtCurrentTable.NewRow();


                    drCurrentRow["Column1"] = box1.Text;


                    rowIndex++;
                }

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                gv_read.DataSource = dtCurrentTable;
                gv_read.DataBind();
            }
        }

        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetPreviousData();
    }
    private void AddNewRowToGrid1()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {

                for (int i = 1; i <= gv_write.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)gv_write.Rows[rowIndex].Cells[0].FindControl("TextBox2");
                    drCurrentRow = dtCurrentTable.NewRow();


                    drCurrentRow["Column1"] = box1.Text;


                    rowIndex++;
                }

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable1"] = dtCurrentTable;

                gv_write.DataSource = dtCurrentTable;
                gv_write.DataBind();
            }
        }

        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetPreviousData1();
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    
                    TextBox box1 = (TextBox)gv_read.Rows[rowIndex].Cells[0].FindControl("TextBox1");
                    
                    box1.Text = dt.Rows[i]["Column1"].ToString();


                    rowIndex++;

                }
            }

        }
    }
    private void SetPreviousData1()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable1"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)gv_write.Rows[rowIndex].Cells[0].FindControl("TextBox2");

                    box1.Text = dt.Rows[i]["Column1"].ToString();


                    rowIndex++;

                }
            }

        }
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }
    protected void ButtonAdd0_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid1();
    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        LabelMessage.Text = "";
        Response.Redirect(Request.Url.ToString());
    }
    private void bindtreeview()
    {
        string rd = "ab,cd,ef";
        string[] wordRd = rd.Split(',');
        string wrt = "a,b,c";
        string[] wordRw = wrt.Split(',');
        string[,] ParentNode = new string[100, 6];
        int count = 0;
        count = 1;

        TreeNode parenttext = new TreeNode();
        parenttext.Text = "Basic ID";
        for (int loop = 0; loop < count; loop++)
        {
            TreeNode parentvalue = new TreeNode();
            parentvalue.Text = "1234";
            parenttext.ChildNodes.Add(parentvalue);
            TreeNode root = new TreeNode();
            TreeNode root1 = new TreeNode();
            TreeNode root2 = new TreeNode();
            TreeNode root3 = new TreeNode();
            TreeNode root4 = new TreeNode();
            TreeNode root5 = new TreeNode();
            root.Text = "Name";
            root1.Text = "Description";
            root2.Text = "Expire Time";
            root3.Text = "Expire Size";
            root4.Text = "Read";
            root5.Text = "Write";
            parentvalue.ChildNodes.Add(root);
            parentvalue.ChildNodes.Add(root1);
            parentvalue.ChildNodes.Add(root2);
            parentvalue.ChildNodes.Add(root3);
            parentvalue.ChildNodes.Add(root4);
            parentvalue.ChildNodes.Add(root5);

            TreeNode rootval = new TreeNode();
            TreeNode root1val = new TreeNode();
            TreeNode root2val = new TreeNode();
            TreeNode root3val = new TreeNode();

            rootval.Text = "suman";
            root1val.Text = "Lives In Kalyani";
            root2val.Text = "12230";
            root3val.Text = "1233490";

            root.ChildNodes.Add(rootval);
            root1.ChildNodes.Add(root1val);
            root2.ChildNodes.Add(root2val);
            root3.ChildNodes.Add(root3val);
            foreach (string rd1 in wordRd)
            {
                TreeNode child = new TreeNode();
                child.Text = rd1;
                root4.ChildNodes.Add(child);

            }
            foreach (string rd2 in wordRw)
            {
                TreeNode child = new TreeNode();
                child.Text = rd2;
                root5.ChildNodes.Add(child);

            }

            TreeView1.Nodes.Add(parenttext);

        }
        TreeView1.CollapseAll();


    }
}