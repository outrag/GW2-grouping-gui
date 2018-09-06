using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GW2API
{
    public partial class Form1 : Form
    {
        string path = @"APIKey.txt";
        string selectedAPIKey = "";
        string selectID = "";
        #region squad&group
        JArray squad_obj = new JArray();
        JArray group1_obj = new JArray();
        JArray group2_obj = new JArray();
        JArray group3_obj = new JArray();
        JArray group4_obj = new JArray();
        JArray group5_obj = new JArray();
        JArray group6_obj = new JArray();
        JArray group7_obj = new JArray();
        JArray group8_obj = new JArray();
        #endregion

        public Form1()
        {
            InitializeComponent();
            refreshForm();
        }

        private void refreshForm()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string s;
                listBox_APIKey.Items.Clear();
                comboBox_nameList.Items.Clear();
                while ((s = sr.ReadLine()) != null)
                {
                    listBox_APIKey.Items.Add(s);
                    comboBox_nameList.Items.Add(s.Split(',')[0]);
                }
                listBox_APIKey.SelectedIndex = 0;
                comboBox_nameList.SelectedIndex = 0;
                comboBox_selectGroup.SelectedIndex = 0;
                button_addChar.Enabled = false;
            }
        }

        private void refreshSquad()
        {
            tableLayoutPanel_squad.Controls.Clear();
            squad_obj.RemoveAll();

            #region combine new squad obj
            squad_obj.Add(group1_obj);
            squad_obj.Add(group2_obj);
            squad_obj.Add(group3_obj);
            squad_obj.Add(group4_obj);
            squad_obj.Add(group5_obj);
            squad_obj.Add(group6_obj);
            squad_obj.Add(group7_obj);
            squad_obj.Add(group8_obj);
            #endregion
            
            int i = 0;
            foreach (var group in squad_obj)
            {
                int j = 0;
                foreach (var member in group)
                {
                    Button bt = new Button();
                    bt.BackColor = Color.MediumTurquoise;
                    bt.FlatStyle = FlatStyle.Flat;
                    bt.FlatAppearance.BorderSize = 0;
                    bt.Size = new Size(40, 40);

                    bt.Image = Image.FromFile(member["icon"].ToString());
                    bt.MouseHover += (s, e) => { textBox_showID.Text = member["id"].ToString(); };
                    bt.MouseLeave += (s, e) => { textBox_showID.Text = ""; };
                    bt.Click += (s, e) => { refreshUserBuilds(member["id"].ToString(), member["character"].ToString(), member["icon"].ToString(), member["group"].ToString(), Convert.ToInt32(member["order"]), member["key"].ToString()); };
                    tableLayoutPanel_squad.Controls.Add(bt, j, i);
                    j++;
                }
                i++;
            }
            
        }

        private void clearUserBuilds()
        {
            pictureBox_icon.Image = null;
            label_Name.Text = "";
            pictureBox_WeaponA1.ImageLocation = null;
            pictureBox_WeaponA2.ImageLocation = null;
            pictureBox_WeaponB1.ImageLocation = null;
            pictureBox_WeaponB2.ImageLocation = null;
            pictureBox_Skill6.Image = null;
            pictureBox_Skill7.Image = null;
            pictureBox_Skill8.Image = null;
            pictureBox_Skill9.Image = null;
            pictureBox_Skill0.Image = null;
            pictureBox_specialization1.Image = null;
            pictureBox_specialization2.Image = null;
            pictureBox_specialization3.Image = null;
            label_specialization1.Text = "";
            label_specialization2.Text = "";
            label_specialization3.Text = "";
        }

        private void refreshUserBuilds(string id, string character, string icon, string group, int order, string key)
        {
            progressBar1.Maximum = 29;
            progressBar1.Value = 0;
            try
            {
                clearUserBuilds();

                #region set icon(1)
                pictureBox_icon.Image = Image.FromFile(icon);
                progressBar1.Value = progressBar1.Value + 1;
                #endregion

                #region set Name(1)
                label_Name.Text = character;
                progressBar1.Value = progressBar1.Value + 1;
                #endregion

                //progressBar(24)
                var ret_value = common.getUserBuilds(character, order, key, progressBar1);
                bool isRevanant = ret_value.Item1;
                string[] weapons = ret_value.Item2;
                string[] skills = ret_value.Item3;
                JObject specializations = ret_value.Item4;
                #region set Weapon(1)
                //string[] weapons = common._getCharacterWeapons(character, key);

                if (!string.IsNullOrEmpty(weapons[0]))
                    pictureBox_WeaponA1.Load(weapons[0]);
                if (!string.IsNullOrEmpty(weapons[1]))
                    pictureBox_WeaponA2.Load(weapons[1]);
                if (!string.IsNullOrEmpty(weapons[2]))
                    pictureBox_WeaponB1.Load(weapons[2]);
                if (!string.IsNullOrEmpty(weapons[3]))
                    pictureBox_WeaponB2.Load(weapons[3]);
                progressBar1.Value = progressBar1.Value + 1;
                #endregion

                #region set Skill(1)
                //string[] skills = common._getCharacterSkills(character, order, key, out isRevanant);
                if (isRevanant)
                {
                    if (!string.IsNullOrEmpty(skills[0]))
                        pictureBox_Skill6.Image = Image.FromFile(skills[0]);
                    if (!string.IsNullOrEmpty(skills[1]))
                        pictureBox_Skill7.Image = Image.FromFile(skills[1]);
                }
                else
                {
                    if (!string.IsNullOrEmpty(skills[0]))
                        pictureBox_Skill6.Load(skills[0]);
                    if (!string.IsNullOrEmpty(skills[1]))
                        pictureBox_Skill7.Load(skills[1]);
                    if (!string.IsNullOrEmpty(skills[2]))
                        pictureBox_Skill8.Load(skills[2]);
                    if (!string.IsNullOrEmpty(skills[3]))
                        pictureBox_Skill9.Load(skills[3]);
                    if (!string.IsNullOrEmpty(skills[4]))
                        pictureBox_Skill0.Load(skills[4]);
                }
                progressBar1.Value = progressBar1.Value + 1;
                #endregion

                #region specialization(1)
                //JObject specializations = common._getCharacterSpecializations(character, key);
                //specialization_1
                if (!string.IsNullOrEmpty(specializations["special_1"]["icon"].ToString()))
                {
                    pictureBox_specialization1.Load(specializations["special_1"]["icon"].ToString());
                    label_specialization1.Text = specializations["special_1"]["trait1"].ToString() + specializations["special_1"]["trait2"].ToString() + specializations["special_1"]["trait3"].ToString();
                }
                //specialization_2
                if (!string.IsNullOrEmpty(specializations["special_2"]["icon"].ToString()))
                {
                    pictureBox_specialization2.Load(specializations["special_2"]["icon"].ToString());
                    label_specialization2.Text = specializations["special_2"]["trait1"].ToString() + specializations["special_2"]["trait2"].ToString() + specializations["special_2"]["trait3"].ToString();
                }
                //specialization_3
                if (!string.IsNullOrEmpty(specializations["special_3"]["icon"].ToString()))
                {
                    pictureBox_specialization3.Load(specializations["special_3"]["icon"].ToString());
                    label_specialization3.Text = specializations["special_3"]["trait1"].ToString() + specializations["special_3"]["trait2"].ToString() + specializations["special_3"]["trait3"].ToString();
                }
                progressBar1.Value = progressBar1.Value + 1;
                #endregion

                textBox1.Text = "refresh " + character + "(" + selectID + ")" + " build success!";
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private bool checkUser(string id)
        {
            foreach (var group in squad_obj)
            {
                foreach (var member in group)  //查找某个字段与值
                {
                    if (member["id"].ToString().Equals(id))
                        return true;
                }
            }
            return false;
        }

        private void removeUser(string id)
        {
            IList<JToken> delList = new List<JToken>();
            string groupNumber = "Group1";

            foreach (var group in squad_obj)
            {
                foreach (var member in group)  //查找某个字段与值
                {
                    if (member["id"].ToString().Equals(id))
                    {
                        delList.Add(member);
                        groupNumber = member["group"].ToString();
                    }
                }
            }

            foreach (var item in delList)  //移除mJObj  在delList 里的项
            {
                int s = Convert.ToInt32(groupNumber.Replace("Group", "")) - 1;
                JArray a = (JArray)squad_obj[s];
                a.Remove(item);
            }

            //refresh Squad JArray
            refreshSquad();
        }

        private void button_uploadAPIKey_Click(object sender, EventArgs e)
        {
            try
            {
                //get account info
                string response = HttpHelper.HttpGet("https://api.guildwars2.com/v2/account?access_token=" + Uri.EscapeDataString(textBox_uploadAPIKey.Text));
                JObject obj = JObject.Parse(response);
                string name = obj["name"].ToString();

                //check is name exist
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s.Split(',')[0].Equals(name))
                                throw new Exception("user exist!");
                        }
                    }
                }
                else
                    throw new Exception("APIKey.txt not exist!");

                //write to txt
                using (StreamWriter sw = new StreamWriter(path, true, new UTF8Encoding(false)))
                {
                    sw.WriteLine(name + ',' + textBox_uploadAPIKey.Text);
                    sw.Flush();
                }

                refreshForm();
                textBox_Message1.Text = "write new user success!";
            }
            catch (Exception ex)
            {
                textBox_Message1.Text = ex.Message;
            }
        }

        private void button_DeleteSelectAPIKey_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> file = new List<string>();
                string name = listBox_APIKey.SelectedItem.ToString().Split(',')[0];

                using (StreamReader sr = new StreamReader(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (!s.Split(',')[0].Equals(name))
                            file.Add(s);
                    }
                }

                using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(false)))
                {
                    foreach (string z in file)
                        sw.WriteLine(z);
                    sw.Flush();
                }

                refreshForm();
                textBox_Message1.Text = "delete success!";
            }
            catch(Exception ex)
            {
                textBox_Message1.Text = ex.Message;
            }
        }

        private void button_selectUser_Click(object sender, EventArgs e)
        {
            button_addChar.Enabled = false;
            progressBar1.Maximum = 4;
            progressBar1.Value = 0;
            try
            {
                //get user's API Key
                string id = comboBox_nameList.SelectedItem.ToString();
                using (StreamReader sr = new StreamReader(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Split(',')[0].Equals(id))
                        {
                            selectID = s.Split(',')[0];
                            selectedAPIKey = s.Split(',')[1];
                        }
                    }
                }
                progressBar1.Value = progressBar1.Value + 1;

                //get account info
                checkedListBox_Characters.Items.Clear();
                string response = HttpHelper.HttpGet("https://api.guildwars2.com/v2/characters?access_token=" + Uri.EscapeDataString(selectedAPIKey));
                JArray obj = JArray.Parse(response);
                foreach (var charname in obj)
                    checkedListBox_Characters.Items.Add(charname.ToString());
                progressBar1.Value = progressBar1.Value + 2;

                checkedListBox_Characters.Height = checkedListBox_Characters.PreferredHeight;
                progressBar1.Value = progressBar1.Value + 1;
            }
            catch(Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void checkedListBox_Characters_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                foreach (int i in checkedListBox_Characters.CheckedIndices)
                    checkedListBox_Characters.SetItemCheckState(i, CheckState.Unchecked);

                button_addChar.Enabled = true;
            }
            else
            {
                button_addChar.Enabled = false;
            }
        }
        
        private void button_addChar_Click(object sender, EventArgs e)
        {
            string group = comboBox_selectGroup.SelectedItem.ToString();
            progressBar1.Maximum = 5;
            progressBar1.Value = 0;
            try
            {
                if (checkedListBox_Characters.SelectedItem == null)
                    throw new Exception("null selected!");

                string character = checkedListBox_Characters.SelectedItem.ToString();

                //check if user exist
                if (checkUser(selectID))
                    removeUser(selectID);
                progressBar1.Value = progressBar1.Value + 1;

                int order = 0;
                JObject member_obj = new JObject();
                member_obj.Add("id", selectID);
                member_obj.Add("character", character);
                member_obj.Add("icon", common.getProfessionIconPath(character, selectedAPIKey, out order));
                member_obj.Add("order", order);
                member_obj.Add("group", group);
                member_obj.Add("key", selectedAPIKey);
                progressBar1.Value = progressBar1.Value + 2;

                #region member obj set in Group JArray
                switch (group)
                {
                    case "Group2":
                        group2_obj.Add(member_obj);
                        group2_obj = common.sortGroup(group2_obj);
                        break;
                    case "Group3":
                        group3_obj.Add(member_obj);
                        group3_obj = common.sortGroup(group3_obj);
                        break;
                    case "Group4":
                        group4_obj.Add(member_obj);
                        group4_obj = common.sortGroup(group4_obj);
                        break;
                    case "Group5":
                        group5_obj.Add(member_obj);
                        group5_obj = common.sortGroup(group5_obj);
                        break;
                    case "Group6":
                        group6_obj.Add(member_obj);
                        group6_obj = common.sortGroup(group6_obj);
                        break;
                    case "Group7":
                        group7_obj.Add(member_obj);
                        group7_obj = common.sortGroup(group7_obj);
                        break;
                    case "Group8":
                        group8_obj.Add(member_obj);
                        group8_obj = common.sortGroup(group8_obj);
                        break;
                    default:
                        group1_obj.Add(member_obj);
                        group1_obj = common.sortGroup(group1_obj);
                        break;
                }
                #endregion
                progressBar1.Value = progressBar1.Value + 1;

                //refresh Squad JArray
                refreshSquad();
                progressBar1.Value = progressBar1.Value + 1;

                textBox1.Text = "add " + character + "(" + selectID + ")" + " into " + group + " success!";
            }
            catch(Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button_removeChar_Click(object sender, EventArgs e)
        {
            try
            {
                removeUser(selectID);
                textBox1.Text = "Done.";
            }
            catch(Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

    }
}
