using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GW2API
{
    class common
    {
        internal static string getProfessionIconPath(string charName, string key, out int order)
        {
            #region get elite specialization icon bitmap
            string response = HttpHelper.HttpGet("https://api.guildwars2.com/v2/characters/" + Uri.EscapeDataString(charName) + "/specializations?access_token=" + Uri.EscapeDataString(key));
            JObject specializations_obj = JObject.Parse(response);
            foreach (var s in specializations_obj["specializations"]["wvw"])
            {
                int id = Convert.ToInt32(s["id"]);
                switch(id)
                {
                    case 5:
                        order = 26;
                        return Application.StartupPath + "\\icons\\1128575.png";
                    case 7:
                        order = 20;
                        return Application.StartupPath + "\\icons\\1128571.png";
                    case 18:
                        order = 8;
                        return Application.StartupPath + "\\icons\\1128567.png";
                    case 27:
                        order = 2;
                        return Application.StartupPath + "\\icons\\1128573.png";
                    case 34:
                        order = 11;
                        return Application.StartupPath + "\\icons\\1128579.png";
                    case 40:
                        order = 17;
                        return Application.StartupPath + "\\icons\\1128569.png";
                    case 43:
                        order = 23;
                        return Application.StartupPath + "\\icons\\1128581.png";
                    case 48:
                        order = 14;
                        return Application.StartupPath + "\\icons\\1128583.png";
                    case 52:
                        order = 5;
                        return Application.StartupPath + "\\icons\\1128577.png";
                    case 55:
                        order = 27;
                        return Application.StartupPath + "\\icons\\1770215.png";
                    case 56:
                        order = 15;
                        return Application.StartupPath + "\\icons\\1670506.png";
                    case 57:
                        order = 24;
                        return Application.StartupPath + "\\icons\\1770225.png";
                    case 58:
                        order = 21;
                        return Application.StartupPath + "\\icons\\1770213.png";
                    case 59:
                        order = 18;
                        return Application.StartupPath + "\\icons\\1770217.png";
                    case 60:
                        order = 12;
                        return Application.StartupPath + "\\icons\\1770221.png";
                    case 61:
                        order = 9;
                        return Application.StartupPath + "\\icons\\1770223.png";
                    case 62:
                        order = 3;
                        return Application.StartupPath + "\\icons\\1770211.png";
                    case 63:
                        order = 6;
                        return Application.StartupPath + "\\icons\\1770219.png";
                    default:
                        break;
                }
            }
            #endregion

            #region otherwise, get profession icon bitmap
            response = HttpHelper.HttpGet("https://api.guildwars2.com/v2/characters/" + Uri.EscapeDataString(charName) + "/core?access_token=" + Uri.EscapeDataString(key));
            JArray core_obj = JArray.Parse(response);
            switch(core_obj["profession"].ToString())
            {
                case "Guardian":
                    order = 1;
                    return Application.StartupPath + "\\icons\\156634.png";
                case "Warrior":
                    order = 7;
                    return Application.StartupPath + "\\icons\\156643.png";
                case "Engineer":
                    order = 22;
                    return Application.StartupPath + "\\icons\\156632.png";
                case "Ranger":
                    order = 25;
                    return Application.StartupPath + "\\icons\\156640.png";
                case "Thief":
                    order = 19;
                    return Application.StartupPath + "\\icons\\156641.png";
                case "Elementalist":
                    order = 13;
                    return Application.StartupPath + "\\icons\\156630.png";
                case "Mesmer":
                    order = 16;
                    return Application.StartupPath + "\\icons\\156636.png";
                case "Necromancer":
                    order = 10;
                    return Application.StartupPath + "\\icons\\156638.png";
                case "Revenant":
                    order = 4;
                    return Application.StartupPath + "\\icons\\961390.png";
                default:
                    throw new Exception("unknown professtion!");
            }
            #endregion
        }

        internal static JArray sortGroup(JArray group)
        {
            return new JArray(group.OrderBy(obj => obj["order"]));
        }
        
        private static string getWeaponIcon(string id)
        {
            string response = HttpHelper.HttpGet("https://api.guildwars2.com/v2/items/" + id + "?lang=en");
            JObject weapon_obj = JObject.Parse(response);
            switch (weapon_obj["details"]["type"].ToString())
            {
                case "Axe":
                    return Application.StartupPath + "\\icons\\axe.png";
                case "Dagger":
                    return Application.StartupPath + "\\icons\\dagger.png";
                case "Mace":
                    return Application.StartupPath + "\\icons\\mace.png";
                case "Pistol":
                    return Application.StartupPath + "\\icons\\pistol.png";
                case "Sword":
                    return Application.StartupPath + "\\icons\\sword.png";
                case "Scepter":
                    return Application.StartupPath + "\\icons\\scepter.png";
                case "Focus":
                    return Application.StartupPath + "\\icons\\focus.png";
                case "Shield":
                    return Application.StartupPath + "\\icons\\shield.png";
                case "Torch":
                    return Application.StartupPath + "\\icons\\torch.png";
                case "Warhorn":
                    return Application.StartupPath + "\\icons\\warhorn.png";
                case "Greatsword":
                    return Application.StartupPath + "\\icons\\greatsword.png";
                case "Hammer":
                    return Application.StartupPath + "\\icons\\hammer.png";
                case "LongBow":
                    return Application.StartupPath + "\\icons\\longbow.png";
                case "Rifle":
                    return Application.StartupPath + "\\icons\\rifle.png";
                case "ShortBow":
                    return Application.StartupPath + "\\icons\\shortbow.png";
                case "Staff":
                    return Application.StartupPath + "\\icons\\staff.png";
                default:
                    throw new Exception("unknown weapon type!");
            }
        }

        private static string getSkillIcon(string id)
        {
            string response = HttpHelper.HttpGet("https://api.guildwars2.com/v2/skills/" + id + "?lang=en");
            JObject skill_obj = JObject.Parse(response);
            return skill_obj["icon"].ToString();
        }

        private static string getLegendIcon(string label)
        {
            switch(label)
            {
                case "Legend1":
                    return Application.StartupPath + "\\icons\\Legend1.png";
                case "Legend2":
                    return Application.StartupPath + "\\icons\\Legend2.png";
                case "Legend3":
                    return Application.StartupPath + "\\icons\\Legend3.png";
                case "Legend4":
                    return Application.StartupPath + "\\icons\\Legend4.png";
                case "Legend5":
                    return Application.StartupPath + "\\icons\\Legend5.png";
                case "Legend6":
                    return Application.StartupPath + "\\icons\\Legend6.png";
                default:
                    throw new Exception("unknown Legend!");
            }
        }

        private static string getSpecializationIcon(string id)
        {
            string response = HttpHelper.HttpGet("https://api.guildwars2.com/v2/specializations/" + id + "?lang=en");
            JObject skill_obj = JObject.Parse(response);
            return skill_obj["icon"].ToString();
        }

        private static string getTraitOrder(string id)
        {
            string response = HttpHelper.HttpGet("https://api.guildwars2.com/v2/traits/" + id + "?lang=en");
            JObject skill_obj = JObject.Parse(response);
            return (Convert.ToInt32(skill_obj["order"]) + 1).ToString();
        }

        private delegate string myDelegate(string id);

        internal static string[] _getCharacterWeapons(string charName, string key)
        {
            string[] weapons = new string[4];
            string response = HttpHelper.HttpGet("https://api.guildwars2.com/v2/characters/" + Uri.EscapeDataString(charName) + "/equipment?access_token=" + Uri.EscapeDataString(key));
            JObject equipment_obj = JObject.Parse(response);
            #region delegate
            myDelegate del1 = new myDelegate(getWeaponIcon);
            IAsyncResult result1 = null;
            myDelegate del2 = new myDelegate(getWeaponIcon);
            IAsyncResult result2 = null;
            myDelegate del3 = new myDelegate(getWeaponIcon);
            IAsyncResult result3 = null;
            myDelegate del4 = new myDelegate(getWeaponIcon);
            IAsyncResult result4 = null;
            #endregion

            #region delegate BeginInvoke
            foreach (var s in equipment_obj["equipment"])
            {
                switch (s["slot"].ToString())
                {
                    case "WeaponA1":
                        result1 = del1.BeginInvoke(s["id"].ToString(), null, null);
                        break;
                    case "WeaponA2":
                        result2 = del2.BeginInvoke(s["id"].ToString(), null, null);
                        break;
                    case "WeaponB1":
                        result3 = del3.BeginInvoke(s["id"].ToString(), null, null);
                        break;
                    case "WeaponB2":
                        result4 = del4.BeginInvoke(s["id"].ToString(), null, null);
                        break;
                    default:
                        continue;
                }
            }
            #endregion

            #region delegate EndInvoke
            if (result1 != null)
                weapons[0] = del1.EndInvoke(result1);
            if (result2 != null)
                weapons[1] = del2.EndInvoke(result2);
            if (result3 != null)
                weapons[2] = del3.EndInvoke(result3);
            if (result4 != null)
                weapons[3] = del4.EndInvoke(result4);
            #endregion

            return weapons;
        }

        internal static string[] _getCharacterSkills(string charName, int order, string key, out bool isRevenant)
        {
            string[] skills = new string[5];
            string response = HttpHelper.HttpGet("https://api.guildwars2.com/v2/characters/" + Uri.EscapeDataString(charName) + "/skills?access_token=" + Uri.EscapeDataString(key));
            JObject skills_obj = JObject.Parse(response);
            #region delegate
            myDelegate del1 = new myDelegate(getSkillIcon);
            IAsyncResult result1 = null;
            myDelegate del2 = new myDelegate(getSkillIcon);
            IAsyncResult result2 = null;
            myDelegate del3 = new myDelegate(getSkillIcon);
            IAsyncResult result3 = null;
            myDelegate del4 = new myDelegate(getSkillIcon);
            IAsyncResult result4 = null;
            myDelegate del5 = new myDelegate(getSkillIcon);
            IAsyncResult result5 = null;
            #endregion

            #region delegate BeginInvoke
            if (order.Equals(4) || order.Equals(5) | order.Equals(6))
            {
                #region Revenant
                isRevenant = true;
                if (skills_obj["skills"]["wvw"]["legends"][0] != null)
                    skills[0] = getLegendIcon(skills_obj["skills"]["wvw"]["legends"][0].ToString());
                if (skills_obj["skills"]["wvw"]["legends"][1] != null)
                    skills[1] = getLegendIcon(skills_obj["skills"]["wvw"]["legends"][1].ToString());
                #endregion
            }
            else
            {
                #region default, use delegate
                isRevenant = false;
                //skill6
                result1 = del1.BeginInvoke(skills_obj["skills"]["wvw"]["heal"].ToString(), null, null);
                //skill7
                result2 = del2.BeginInvoke(skills_obj["skills"]["wvw"]["utilities"][0].ToString(), null, null);
                //skill8
                result3 = del3.BeginInvoke(skills_obj["skills"]["wvw"]["utilities"][1].ToString(), null, null);
                //skill9
                result4 = del4.BeginInvoke(skills_obj["skills"]["wvw"]["utilities"][2].ToString(), null, null);
                //skill0
                result5 = del5.BeginInvoke(skills_obj["skills"]["wvw"]["elite"].ToString(), null, null);
                #endregion
            }
            #endregion

            #region delegate EndInvoke
            if (result1 != null)
                skills[0] = del1.EndInvoke(result1);
            if (result2 != null)
                skills[1] = del2.EndInvoke(result2);
            if (result3 != null)
                skills[2] = del3.EndInvoke(result3);
            if (result4 != null)
                skills[3] = del4.EndInvoke(result4);
            if (result5 != null)
                skills[4] = del5.EndInvoke(result5);
            #endregion
            
            return skills;
        }

        internal static JObject _getCharacterSpecializations(string charName, string key)
        {
            JObject return_obj = new JObject();
            string response = HttpHelper.HttpGet("https://api.guildwars2.com/v2/characters/" + Uri.EscapeDataString(charName) + "/specializations?access_token=" + Uri.EscapeDataString(key));
            JObject specializations_obj = JObject.Parse(response);
            #region delegate
            //special1, trait1~3
            myDelegate del1_icon = new myDelegate(getSpecializationIcon);
            IAsyncResult result1_icon = null;
            myDelegate del1_trait1 = new myDelegate(getTraitOrder);
            IAsyncResult result1_trait1 = null;
            myDelegate del1_trait2 = new myDelegate(getTraitOrder);
            IAsyncResult result1_trait2 = null;
            myDelegate del1_trait3 = new myDelegate(getTraitOrder);
            IAsyncResult result1_trait3 = null;
            //special2, trait1~3
            myDelegate del2_icon = new myDelegate(getSpecializationIcon);
            IAsyncResult result2_icon = null;
            myDelegate del2_trait1 = new myDelegate(getTraitOrder);
            IAsyncResult result2_trait1 = null;
            myDelegate del2_trait2 = new myDelegate(getTraitOrder);
            IAsyncResult result2_trait2 = null;
            myDelegate del2_trait3 = new myDelegate(getTraitOrder);
            IAsyncResult result2_trait3 = null;
            //special3, trait1~3
            myDelegate del3_icon = new myDelegate(getSpecializationIcon);
            IAsyncResult result3_icon = null;
            myDelegate del3_trait1 = new myDelegate(getTraitOrder);
            IAsyncResult result3_trait1 = null;
            myDelegate del3_trait2 = new myDelegate(getTraitOrder);
            IAsyncResult result3_trait2 = null;
            myDelegate del3_trait3 = new myDelegate(getTraitOrder);
            IAsyncResult result3_trait3 = null;
            #endregion

            #region specialization_1, trait1~3
            JObject obj1 = new JObject();
            if (specializations_obj["specializations"]["wvw"][0] == null)
            {
                obj1.Add("icon", "");
                obj1.Add("trait1", "");
                obj1.Add("trait2", "");
                obj1.Add("trait3", "");
            }
            else
            {
                result1_icon = del1_icon.BeginInvoke(specializations_obj["specializations"]["wvw"][0]["id"].ToString(), null, null);
                //trait1
                if (specializations_obj["specializations"]["wvw"][0]["traits"][0] == null)
                    obj1.Add("trait1", "0");
                else
                    result1_trait1 = del1_trait1.BeginInvoke(specializations_obj["specializations"]["wvw"][0]["traits"][0].ToString(), null, null);
                //trait2
                if (specializations_obj["specializations"]["wvw"][0]["traits"][1] == null)
                    obj1.Add("trait2", "0");
                else
                    result1_trait2 = del1_trait2.BeginInvoke(specializations_obj["specializations"]["wvw"][0]["traits"][1].ToString(), null, null);
                //trait3
                if (specializations_obj["specializations"]["wvw"][0]["traits"][2] == null)
                    obj1.Add("trait3", "0");
                else
                    result1_trait3 = del1_trait3.BeginInvoke(specializations_obj["specializations"]["wvw"][0]["traits"][2].ToString(), null, null);
            }
            #endregion
            #region specialization_2, trait1~3
            JObject obj2 = new JObject();
            if (specializations_obj["specializations"]["wvw"][1] == null)
            {
                obj2.Add("icon", "");
                obj2.Add("trait1", "");
                obj2.Add("trait2", "");
                obj2.Add("trait3", "");
            }
            else
            {
                result2_icon = del2_icon.BeginInvoke(specializations_obj["specializations"]["wvw"][1]["id"].ToString(), null, null);
                //trait1
                if (specializations_obj["specializations"]["wvw"][1]["traits"][0] == null)
                    obj2.Add("trait1", "0");
                else
                    result2_trait1 = del2_trait1.BeginInvoke(specializations_obj["specializations"]["wvw"][1]["traits"][0].ToString(), null, null);
                //trait2
                if (specializations_obj["specializations"]["wvw"][1]["traits"][1] == null)
                    obj2.Add("trait2", "0");
                else
                    result2_trait2 = del2_trait2.BeginInvoke(specializations_obj["specializations"]["wvw"][1]["traits"][1].ToString(), null, null);
                //trait3
                if (specializations_obj["specializations"]["wvw"][1]["traits"][2] == null)
                    obj2.Add("trait3", "0");
                else
                    result2_trait3 = del2_trait3.BeginInvoke(specializations_obj["specializations"]["wvw"][1]["traits"][2].ToString(), null, null);
            }
            #endregion
            #region specialization_3, trait1~3
            JObject obj3 = new JObject();
            if (specializations_obj["specializations"]["wvw"][2] == null)
            {
                obj3.Add("icon", "");
                obj3.Add("trait1", "");
                obj3.Add("trait2", "");
                obj3.Add("trait3", "");
            }
            else
            {
                result3_icon = del3_icon.BeginInvoke(specializations_obj["specializations"]["wvw"][2]["id"].ToString(), null, null);
                //trait1
                if (specializations_obj["specializations"]["wvw"][2]["traits"][0] == null)
                    obj3.Add("trait1", "0");
                else
                    result3_trait1 = del3_trait1.BeginInvoke(specializations_obj["specializations"]["wvw"][2]["traits"][0].ToString(), null, null);
                //trait2
                if (specializations_obj["specializations"]["wvw"][2]["traits"][1] == null)
                    obj3.Add("trait2", "0");
                else
                    result3_trait2 = del3_trait2.BeginInvoke(specializations_obj["specializations"]["wvw"][2]["traits"][1].ToString(), null, null);
                //trait3
                if (specializations_obj["specializations"]["wvw"][2]["traits"][2] == null)
                    obj3.Add("trait3", "0");
                else
                    result3_trait3 = del3_trait3.BeginInvoke(specializations_obj["specializations"]["wvw"][2]["traits"][2].ToString(), null, null);
            }
            #endregion

            #region delegate EndInvoke
            #region specialization_1, trait1~3
            if (result1_icon != null)
                obj1.Add("icon", del1_icon.EndInvoke(result1_icon));
            if (result1_trait1 != null)
                obj1.Add("trait1", del1_trait1.EndInvoke(result1_trait1));
            if (result1_trait2 != null)
                obj1.Add("trait2", del1_trait2.EndInvoke(result1_trait2));
            if (result1_trait3 != null)
                obj1.Add("trait3", del1_trait3.EndInvoke(result1_trait3));
            #endregion
            #region specialization_2, trait1~3
            if (result2_icon != null)
                obj2.Add("icon", del2_icon.EndInvoke(result2_icon));
            if (result2_trait1 != null)
                obj2.Add("trait1", del2_trait1.EndInvoke(result2_trait1));
            if (result2_trait2 != null)
                obj2.Add("trait2", del2_trait2.EndInvoke(result2_trait2));
            if (result2_trait3 != null)
                obj2.Add("trait3", del2_trait3.EndInvoke(result2_trait3));
            #endregion
            #region specialization_3, trait1~3
            if (result3_icon != null)
                obj3.Add("icon", del3_icon.EndInvoke(result3_icon));
            if (result3_trait1 != null)
                obj3.Add("trait1", del3_trait1.EndInvoke(result3_trait1));
            if (result3_trait2 != null)
                obj3.Add("trait2", del3_trait2.EndInvoke(result3_trait2));
            if (result3_trait3 != null)
                obj3.Add("trait3", del3_trait3.EndInvoke(result3_trait3));
            #endregion
            #region combine JObjects
            return_obj.Add("special_1", obj1);
            return_obj.Add("special_2", obj2);
            return_obj.Add("special_3", obj3);
            #endregion
            #endregion

            return return_obj;
        }

        private static string _getHttpResponse(string uri)
        {
            return HttpHelper.HttpGet(uri);
        }

        internal static Tuple<bool, string[], string[], JObject> getUserBuilds(string charName, int order, string key, ProgressBar progressBar1)
        {
            bool isRevenant = false;
            string[] weapons = new string[4];
            string[] skills = new string[5];
            JObject return_obj = new JObject();
            
            string uri1 = "https://api.guildwars2.com/v2/characters/" + Uri.EscapeDataString(charName) + "/equipment?access_token=" + Uri.EscapeDataString(key);
            myDelegate del_equip = new myDelegate(_getHttpResponse);
            IAsyncResult result_equip = del_equip.BeginInvoke(uri1, null, null);
            
            
            string uri2 = "https://api.guildwars2.com/v2/characters/" + Uri.EscapeDataString(charName) + "/skills?access_token=" + Uri.EscapeDataString(key);
            myDelegate del_skill = new myDelegate(_getHttpResponse);
            IAsyncResult result_skill = del_skill.BeginInvoke(uri2, null, null);
            
            
            string uri3 = "https://api.guildwars2.com/v2/characters/" + Uri.EscapeDataString(charName) + "/specializations?access_token=" + Uri.EscapeDataString(key);
            myDelegate del_spec = new myDelegate(_getHttpResponse);
            IAsyncResult result_spec = del_spec.BeginInvoke(uri3, null, null);
            

            string response_equip = del_equip.EndInvoke(result_equip);
            string response_skill = del_skill.EndInvoke(result_skill);
            string response_spec = del_spec.EndInvoke(result_spec);
            progressBar1.Value = progressBar1.Value + 3;

            #region spec
            JObject specializations_obj = JObject.Parse(response_spec);
            #region delegate
            //special1, trait1~3
            myDelegate del1_icon = new myDelegate(getSpecializationIcon);
            IAsyncResult result1_icon = null;
            myDelegate del1_trait1 = new myDelegate(getTraitOrder);
            IAsyncResult result1_trait1 = null;
            myDelegate del1_trait2 = new myDelegate(getTraitOrder);
            IAsyncResult result1_trait2 = null;
            myDelegate del1_trait3 = new myDelegate(getTraitOrder);
            IAsyncResult result1_trait3 = null;
            //special2, trait1~3
            myDelegate del2_icon = new myDelegate(getSpecializationIcon);
            IAsyncResult result2_icon = null;
            myDelegate del2_trait1 = new myDelegate(getTraitOrder);
            IAsyncResult result2_trait1 = null;
            myDelegate del2_trait2 = new myDelegate(getTraitOrder);
            IAsyncResult result2_trait2 = null;
            myDelegate del2_trait3 = new myDelegate(getTraitOrder);
            IAsyncResult result2_trait3 = null;
            //special3, trait1~3
            myDelegate del3_icon = new myDelegate(getSpecializationIcon);
            IAsyncResult result3_icon = null;
            myDelegate del3_trait1 = new myDelegate(getTraitOrder);
            IAsyncResult result3_trait1 = null;
            myDelegate del3_trait2 = new myDelegate(getTraitOrder);
            IAsyncResult result3_trait2 = null;
            myDelegate del3_trait3 = new myDelegate(getTraitOrder);
            IAsyncResult result3_trait3 = null;
            #endregion

            #region specialization_1, trait1~3
            JObject obj1 = new JObject();
            if (specializations_obj["specializations"]["wvw"][0].Type == JTokenType.Null)
            {
                obj1.Add("icon", "");
                obj1.Add("trait1", "");
                obj1.Add("trait2", "");
                obj1.Add("trait3", "");
            }
            else
            {
                result1_icon = del1_icon.BeginInvoke(specializations_obj["specializations"]["wvw"][0]["id"].ToString(), null, null);
                //trait1
                if (specializations_obj["specializations"]["wvw"][0]["traits"][0].Type != JTokenType.Null)
                    result1_trait1 = del1_trait1.BeginInvoke(specializations_obj["specializations"]["wvw"][0]["traits"][0].ToString(), null, null);
                else
                    obj1.Add("trait1", "X");
                //trait2
                if (specializations_obj["specializations"]["wvw"][0]["traits"][1].Type != JTokenType.Null)
                    result1_trait2 = del1_trait2.BeginInvoke(specializations_obj["specializations"]["wvw"][0]["traits"][1].ToString(), null, null);
                else
                    obj1.Add("trait2", "X");
                //trait3
                if (specializations_obj["specializations"]["wvw"][0]["traits"][2].Type != JTokenType.Null)
                    result1_trait3 = del1_trait3.BeginInvoke(specializations_obj["specializations"]["wvw"][0]["traits"][2].ToString(), null, null);
                else
                    obj1.Add("trait3", "X");
            }
            #endregion
            #region specialization_2, trait1~3
            JObject obj2 = new JObject();
            if (specializations_obj["specializations"]["wvw"][1].Type == JTokenType.Null)
            {
                obj2.Add("icon", "");
                obj2.Add("trait1", "");
                obj2.Add("trait2", "");
                obj2.Add("trait3", "");
            }
            else
            {
                result2_icon = del2_icon.BeginInvoke(specializations_obj["specializations"]["wvw"][1]["id"].ToString(), null, null);
                //trait1
                if (specializations_obj["specializations"]["wvw"][1]["traits"][0].Type != JTokenType.Null)
                    result2_trait1 = del2_trait1.BeginInvoke(specializations_obj["specializations"]["wvw"][1]["traits"][0].ToString(), null, null);
                else
                    obj2.Add("trait1", "X");
                //trait2
                if (specializations_obj["specializations"]["wvw"][1]["traits"][1].Type != JTokenType.Null)
                    result2_trait2 = del2_trait2.BeginInvoke(specializations_obj["specializations"]["wvw"][1]["traits"][1].ToString(), null, null);
                else
                    obj2.Add("trait2", "X");
                //trait3
                if (specializations_obj["specializations"]["wvw"][1]["traits"][2].Type != JTokenType.Null)
                    result2_trait3 = del2_trait3.BeginInvoke(specializations_obj["specializations"]["wvw"][1]["traits"][2].ToString(), null, null);
                else
                    obj2.Add("trait3", "X");
            }
            #endregion
            #region specialization_3, trait1~3
            JObject obj3 = new JObject();
            if (specializations_obj["specializations"]["wvw"][2].Type == JTokenType.Null)
            {
                obj3.Add("icon", "");
                obj3.Add("trait1", "");
                obj3.Add("trait2", "");
                obj3.Add("trait3", "");
            }
            else
            {
                result3_icon = del3_icon.BeginInvoke(specializations_obj["specializations"]["wvw"][2]["id"].ToString(), null, null);
                //trait1
                if (specializations_obj["specializations"]["wvw"][2]["traits"][0].Type != JTokenType.Null)
                    result3_trait1 = del3_trait1.BeginInvoke(specializations_obj["specializations"]["wvw"][2]["traits"][0].ToString(), null, null);
                else
                    obj3.Add("trait1", "X");
                //trait2
                if (specializations_obj["specializations"]["wvw"][2]["traits"][1].Type != JTokenType.Null)
                    result3_trait2 = del3_trait2.BeginInvoke(specializations_obj["specializations"]["wvw"][2]["traits"][1].ToString(), null, null);
                else
                    obj3.Add("trait2", "X");
                //trait3
                if (specializations_obj["specializations"]["wvw"][2]["traits"][2].Type != JTokenType.Null)
                    result3_trait3 = del3_trait3.BeginInvoke(specializations_obj["specializations"]["wvw"][2]["traits"][2].ToString(), null, null);
                else
                    obj3.Add("trait3", "X");
            }
            #endregion
            #endregion

            #region skill
            JObject skills_obj = JObject.Parse(response_skill);
            #region delegate
            myDelegate del1 = new myDelegate(getSkillIcon);
            IAsyncResult result1 = null;
            myDelegate del2 = new myDelegate(getSkillIcon);
            IAsyncResult result2 = null;
            myDelegate del3 = new myDelegate(getSkillIcon);
            IAsyncResult result3 = null;
            myDelegate del4 = new myDelegate(getSkillIcon);
            IAsyncResult result4 = null;
            myDelegate del5 = new myDelegate(getSkillIcon);
            IAsyncResult result5 = null;
            #endregion

            #region delegate BeginInvoke
            if (order.Equals(4) || order.Equals(5) | order.Equals(6))
            {
                #region Revenant
                isRevenant = true;
                if (skills_obj["skills"]["wvw"]["legends"][0].Type != JTokenType.Null)
                    skills[0] = getLegendIcon(skills_obj["skills"]["wvw"]["legends"][0].ToString());
                if (skills_obj["skills"]["wvw"]["legends"][1].Type != JTokenType.Null)
                    skills[1] = getLegendIcon(skills_obj["skills"]["wvw"]["legends"][1].ToString());
                #endregion
            }
            else
            {
                #region default, use delegate
                isRevenant = false;
                //skill6
                if (skills_obj["skills"]["wvw"]["heal"].Type != JTokenType.Null)
                    result1 = del1.BeginInvoke(skills_obj["skills"]["wvw"]["heal"].ToString(), null, null);
                //skill7
                if (skills_obj["skills"]["wvw"]["utilities"][0].Type != JTokenType.Null)
                    result2 = del2.BeginInvoke(skills_obj["skills"]["wvw"]["utilities"][0].ToString(), null, null);
                //skill8
                if (skills_obj["skills"]["wvw"]["utilities"][1].Type != JTokenType.Null)
                    result3 = del3.BeginInvoke(skills_obj["skills"]["wvw"]["utilities"][1].ToString(), null, null);
                //skill9
                if (skills_obj["skills"]["wvw"]["utilities"][2].Type != JTokenType.Null)
                    result4 = del4.BeginInvoke(skills_obj["skills"]["wvw"]["utilities"][2].ToString(), null, null);
                //skill0
                if (skills_obj["skills"]["wvw"]["elite"].Type != JTokenType.Null)
                    result5 = del5.BeginInvoke(skills_obj["skills"]["wvw"]["elite"].ToString(), null, null);
                #endregion
            }
            #endregion
            #endregion

            #region equip
            JObject equipment_obj = JObject.Parse(response_equip);
            #region delegate
            myDelegate dela1 = new myDelegate(getWeaponIcon);
            IAsyncResult resulta1 = null;
            myDelegate dela2 = new myDelegate(getWeaponIcon);
            IAsyncResult resulta2 = null;
            myDelegate dela3 = new myDelegate(getWeaponIcon);
            IAsyncResult resulta3 = null;
            myDelegate dela4 = new myDelegate(getWeaponIcon);
            IAsyncResult resulta4 = null;
            #endregion

            #region delegate BeginInvoke
            foreach (var s in equipment_obj["equipment"])
            {
                switch (s["slot"].ToString())
                {
                    case "WeaponA1":
                        resulta1 = dela1.BeginInvoke(s["id"].ToString(), null, null);
                        break;
                    case "WeaponA2":
                        resulta2 = dela2.BeginInvoke(s["id"].ToString(), null, null);
                        break;
                    case "WeaponB1":
                        resulta3 = dela3.BeginInvoke(s["id"].ToString(), null, null);
                        break;
                    case "WeaponB2":
                        resulta4 = dela4.BeginInvoke(s["id"].ToString(), null, null);
                        break;
                    default:
                        continue;
                }
            }
            #endregion
            #endregion


            #region delegate EndInvoke(spec(12))
            #region specialization_1, trait1~3
            if (result1_icon != null)
                obj1.Add("icon", del1_icon.EndInvoke(result1_icon));
            if (result1_trait1 != null)
                obj1.Add("trait1", del1_trait1.EndInvoke(result1_trait1));
            if (result1_trait2 != null)
                obj1.Add("trait2", del1_trait2.EndInvoke(result1_trait2));
            if (result1_trait3 != null)
                obj1.Add("trait3", del1_trait3.EndInvoke(result1_trait3));
            progressBar1.Value = progressBar1.Value + 4;
            #endregion
            #region specialization_2, trait1~3
            if (result2_icon != null)
                obj2.Add("icon", del2_icon.EndInvoke(result2_icon));
            if (result2_trait1 != null)
                obj2.Add("trait1", del2_trait1.EndInvoke(result2_trait1));
            if (result2_trait2 != null)
                obj2.Add("trait2", del2_trait2.EndInvoke(result2_trait2));
            if (result2_trait3 != null)
                obj2.Add("trait3", del2_trait3.EndInvoke(result2_trait3));
            progressBar1.Value = progressBar1.Value + 4;
            #endregion
            #region specialization_3, trait1~3
            if (result3_icon != null)
                obj3.Add("icon", del3_icon.EndInvoke(result3_icon));
            if (result3_trait1 != null)
                obj3.Add("trait1", del3_trait1.EndInvoke(result3_trait1));
            if (result3_trait2 != null)
                obj3.Add("trait2", del3_trait2.EndInvoke(result3_trait2));
            if (result3_trait3 != null)
                obj3.Add("trait3", del3_trait3.EndInvoke(result3_trait3));
            progressBar1.Value = progressBar1.Value + 4;
            #endregion
            #region combine JObjects
            return_obj.Add("special_1", obj1);
            return_obj.Add("special_2", obj2);
            return_obj.Add("special_3", obj3);
            #endregion
            #endregion

            #region delegate EndInvoke(skill(5))
            if (result1 != null)
                skills[0] = del1.EndInvoke(result1);
            if (result2 != null)
                skills[1] = del2.EndInvoke(result2);
            if (result3 != null)
                skills[2] = del3.EndInvoke(result3);
            if (result4 != null)
                skills[3] = del4.EndInvoke(result4);
            if (result5 != null)
                skills[4] = del5.EndInvoke(result5);
            progressBar1.Value = progressBar1.Value + 5;
            #endregion

            #region delegate EndInvoke(equip(4))
            if (resulta1 != null)
                weapons[0] = dela1.EndInvoke(resulta1);
            if (resulta2 != null)
                weapons[1] = dela2.EndInvoke(resulta2);
            if (resulta3 != null)
                weapons[2] = dela3.EndInvoke(resulta3);
            if (resulta4 != null)
                weapons[3] = dela4.EndInvoke(resulta4);
            progressBar1.Value = progressBar1.Value + 4;
            #endregion

            return Tuple.Create(isRevenant, weapons, skills, return_obj);
        }

    }
}
