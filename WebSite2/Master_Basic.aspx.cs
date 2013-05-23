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
           
            SetInitialRow();
            SetInitialRow1();
            bindtreeview();
            btn_save.Enabled = true;
            btn_update.Enabled = false;
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
        if (rs == "")
        {
            lbl_rd.Text = "Please enter Read";
            goto endPrg;
        }
        else
        {
            lbl_rd.Text = "";
        }
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
        if (wrt == "")
        {
            lbl_wr.Text = "Please enter Write";
            goto endPrg;
        }
        else
        {
            lbl_wr.Text = "";
        }
        string result = objServiceClientobjService.InsertBasicDetails(BasicInfo,rs,wrt);

       LabelMessage.Text = result;
       TextBoxId.Text = "";
       TextBoxDescription.Text="";
       TextBoxSize.Text = "";
       TextBoxName.Text = "";
       TextBoxTime.Text = "";
       SetInitialRow();
       SetInitialRow1();
   endPrg:
       clrTree();
       bindtreeview();
       

    }
   
    protected void btn_update_Click(object sender, EventArgs e)
    {
       
        BasicDetails BasicInfo = new BasicDetails();

        BasicInfo.basicid = TextBoxId.Text;

        BasicInfo.name = TextBoxName.Text;

        BasicInfo.description = TextBoxDescription.Text;

        BasicInfo.expire_t = TextBoxTime.Text;

        BasicInfo.expire_s = TextBoxSize.Text;

      
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

            }
        }
        Editwrt = Editwrt.TrimStart(',');

        string result = objServiceClientobjService.GetUpdatedBasic(BasicInfo, Editrd, Editwrt);

        LabelMessage.Text = result;
        TextBoxId.Text = "";
        TextBoxDescription.Text = "";
        TextBoxSize.Text = "";
        TextBoxName.Text = "";
        TextBoxTime.Text = "";
        SetInitialRow();
        SetInitialRow1();
        bindtreeview();
        btn_save.Enabled = true;
        btn_update.Enabled = false;
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        objServiceClientobjService.DeleteBasicInfo(TextBoxId.Text);
        bindtreeview();
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
        TextBoxId.Enabled = true;
        btn_update.Enabled = false;
        btn_save.Enabled = true;
        Response.Redirect(Request.Url.ToString());
    }
    private void clrTree()
    {
        TreeView1.Nodes.Clear();
        
    }
    private void bindtreeview()
    {
       
        clrTree();
        TreeNode parenttext = new TreeNode();
        parenttext.Text = "Basic ID";
        string prtVl = objServiceClientobjService.getAll();
        string[] wordPrtvl = prtVl.Split(',');
        foreach (string ab in wordPrtvl)
        {


            TreeNode parentvalue = new TreeNode();

            parentvalue.Text = ab;

            parenttext.ChildNodes.Add(parentvalue);
            string Pr_child_nm = "";
            Pr_child_nm = objServiceClientobjService.getBasicInfoNameById(ab);

            TreeNode root = new TreeNode();
            root.Text = "Name";
            parentvalue.ChildNodes.Add(root);
            TreeNode rootval = new TreeNode();
            rootval.Text = Pr_child_nm;
            root.ChildNodes.Add(rootval);

            string Pr_child_desc = "";
            Pr_child_desc = objServiceClientobjService.getBasicInfoDescriptionById(ab);
            TreeNode root1 = new TreeNode();
            root1.Text = "Description";
            parentvalue.ChildNodes.Add(root1);
            TreeNode root1valDesc = new TreeNode();
            root1valDesc.Text = Pr_child_desc;
            root1.ChildNodes.Add(root1valDesc);

            string Pr_child_expT = "";
            Pr_child_expT = objServiceClientobjService.getBasicInfoExpTById(ab);
            TreeNode root2 = new TreeNode();
            root2.Text = "Expire Time";
            parentvalue.ChildNodes.Add(root2);
            TreeNode root2valExpT = new TreeNode();
            root2valExpT.Text = Pr_child_expT;
            root2.ChildNodes.Add(root2valExpT);

            string Pr_child_expS = "";
            Pr_child_expS = objServiceClientobjService.getBasicInfoExpSById(ab);
            TreeNode root3 = new TreeNode();
            root3.Text = "Expire Time";
            parentvalue.ChildNodes.Add(root3);
            TreeNode root3valExpS = new TreeNode();
            root3valExpS.Text = Pr_child_expS;
            root3.ChildNodes.Add(root3valExpS);

            TreeNode root4 = new TreeNode();
            root4.Text = "Read";
            TreeNode root5 = new TreeNode();
            root5.Text = "Write";

            parentvalue.ChildNodes.Add(root4);
            parentvalue.ChildNodes.Add(root5);


            string rd = objServiceClientobjService.getBasicInfoReadId(ab);
            string[] wordRd = rd.Split(',');
            foreach (string rd1 in wordRd)
            {
                TreeNode child = new TreeNode();
                child.Text = rd1;
                root4.ChildNodes.Add(child);

            }
            string wrt = objServiceClientobjService.getBasicInfoWriteId(ab);
            string[] wordRw = wrt.Split(',');
            foreach (string rd2 in wordRw)
            {
                TreeNode child = new TreeNode();
                child.Text = rd2;
                root5.ChildNodes.Add(child);

            }
        }
            TreeView1.Nodes.Add(parenttext);

  
        TreeView1.CollapseAll();


    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
       
        TextBoxId.Enabled = false;
        string SelId = TreeView1.SelectedValue.ToString();
        TextBoxId.Text = SelId;
        TextBoxName.Text = objServiceClientobjService.getBasicInfoNameById(SelId);
        TextBoxDescription.Text = objServiceClientobjService.getBasicInfoDescriptionById(SelId);
        TextBoxSize.Text = objServiceClientobjService.getBasicInfoExpSById(SelId);
        TextBoxTime.Text = objServiceClientobjService.getBasicInfoExpTById(SelId);
        string rd = objServiceClientobjService.getBasicInfoReadId(SelId);
        string[] wordRd = rd.Split(',');

        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));

        foreach (string rd1 in wordRd)
        {
            DataRow dr = dt.NewRow();
            dr[0] = rd1;
            dt.Rows.Add(dr);
        }
        gv_read.DataSource = dt;
        gv_read.DataBind();

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            TextBox box2 = (TextBox)gv_read.Rows[i].Cells[0].FindControl("TextBox1");
            box2.Text = dt.Rows[i][0].ToString();
        }
        ViewState["CurrentTable"] = dt;
        string wrt = objServiceClientobjService.getBasicInfoWriteId(SelId);
        string[] wordRw = wrt.Split(',');
        DataTable dt1 = new DataTable();
        dt1.Columns.Add(new DataColumn("Column1", typeof(string)));
        foreach (string rd2 in wordRw)
        {
            DataRow dr = dt1.NewRow();
            dr[0] = rd2;
            dt1.Rows.Add(dr);
        }
        gv_write.DataSource = dt1;
        gv_write.DataBind();

        for (int i = 0; i <= dt1.Rows.Count - 1; i++)
        {
            TextBox box2 = (TextBox)gv_write.Rows[i].Cells[0].FindControl("TextBox2");
            box2.Text = dt1.Rows[i][0].ToString();
        }
        ViewState["CurrentTable1"] = dt1;
        btn_update.Enabled = true;
        btn_save.Enabled = false;
    }
}