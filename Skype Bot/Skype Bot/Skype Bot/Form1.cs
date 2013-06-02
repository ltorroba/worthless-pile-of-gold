using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SKYPE4COMLib;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace Skype_Bot
{
    public partial class Form1 : Form
    {
        public static Skype skype = new Skype();
        public static Chat chat;
        public static List<TempUser> tempUsers = new List<TempUser>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ((_ISkypeEvents_Event)skype).AttachmentStatus += new _ISkypeEvents_AttachmentStatusEventHandler(Form1_AttachmentStatus);
            skype.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(skype_MessageStatus);

            if (skype.Client.IsRunning)
            {
                listBox2.Items.Add("Skype is running.");
            }

            try
            {
                skype.Attach(8);
            }
            catch (Exception ex)
            {

            }
        }

        private bool TempUserListContains(string speaker)
        {
            bool contains = false;

            foreach (TempUser u in tempUsers)
            {
                if (u.handler == speaker)
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }

        private string GetHandleFromDisplayName(Chat chat, string display)
        {
            throw new NotImplementedException();
        }

        private void Trace(string str)
        {
            listBox2.Items.Add(str);
        }

        private TempUser GetTempUser(string speaker)
        {
            foreach (TempUser u in tempUsers)
            {
                Trace("lulz " + u.handler);
                if (u.handler == speaker)
                {
                    return u;
                }
            }

            return null;
        }

        public void skype_MessageStatus(ChatMessage pMessage, TChatMessageStatus Status)
        {
            #region Speaker Commands

            if (Status != TChatMessageStatus.cmsRead && pMessage.FromHandle != "async.bot" && (speakerList.Items.Contains(pMessage.FromHandle) || masterList.Items.Contains(pMessage.FromHandle)))
            {
                if (pMessage.Body.ToString() == "ping")
                {
                    pMessage.Chat.SendMessage("[BOT]: pong");
                }
                else if (pMessage.Body.ToString() == "pong")
                {
                    pMessage.Chat.SendMessage("[BOT]: ping");
                }                
                else if (pMessage.Body.ToString().StartsWith("!insult "))
                {
                    string speaker = pMessage.Body.ToString().Substring(("!insult ").Length, pMessage.Body.ToString().Length - ("!insult ").Length);

                    pMessage.Chat.SendMessage("[BOT]: " + speaker + " is fat, ugly and hapless.");
                }
                else if (pMessage.Body.ToString().StartsWith("!voteKick "))
                {
                    string speaker = pMessage.Body.ToString().Substring(("!voteKick ").Length, pMessage.Body.ToString().Length - ("!voteKick ").Length);

                    if (!TempUserListContains(speaker))
                    {
                        tempUsers.Add(new TempUser(speaker));
                    }

                    TempUser user = GetTempUser(speaker);
                    
                    try
                    {
                        if (!user.voters.Contains(pMessage.FromHandle))
                        {
                            user.voteKick++;
                            user.voters.Add(pMessage.FromHandle);
                            pMessage.Chat.SendMessage("[BOT]: Thank-you for voting. Vote kick count now at: " + user.voteKick + ".");

                            if (user.voteKick >= 3)
                            {
                                pMessage.Chat.SendMessage("/kick " + speaker);
                                pMessage.Chat.SendMessage("[BOT]: Voting closed. Attempting to kick " + speaker + ".");
                            }
                        }
                        else
                        {
                            pMessage.Chat.SendMessage("[BOT]: " + pMessage.FromHandle + " has already voted!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace(ex.ToString());
                    }
                }
                else if (pMessage.Body.ToString().StartsWith("!voteKickAgainst "))
                {
                    string speaker = pMessage.Body.ToString().Substring(("!voteKickAgainst ").Length, pMessage.Body.ToString().Length - ("!voteKickAgainst ").Length);

                    if (!TempUserListContains(speaker))
                    {
                        tempUsers.Add(new TempUser(speaker));
                    }

                    TempUser user = GetTempUser(speaker);

                    if (!user.voters.Contains(pMessage.FromHandle))
                    {
                        user.voteKick--;
                        user.voters.Add(pMessage.FromHandle);
                        pMessage.Chat.SendMessage("[BOT]: Thank-you for voting. Vote kick count now at: " + user.voteKick + ".");

                        if (user.voteKick >= 3)
                        {
                            pMessage.Chat.SendMessage("/kick " + speaker);
                            pMessage.Chat.SendMessage("[BOT]: Voting closed. Attempting to kick " + speaker + ".");
                        }
                    }
                    else
                    {
                        pMessage.Chat.SendMessage("[BOT]: " + pMessage.FromHandle + " has already voted!");
                    }
                }
                else if (pMessage.Body.ToString().StartsWith("!respect "))
                {
                    string speaker = pMessage.Body.ToString().Substring(("!respect ").Length, pMessage.Body.ToString().Length - ("!respect ").Length);

                    if (!TempUserListContains(speaker))
                    {
                        tempUsers.Add(new TempUser(speaker));
                    }

                    TempUser user = GetTempUser(speaker);

                    if (!user.respecters.Contains(pMessage.FromHandle))
                    {
                        user.respect++;
                        user.respecters.Add(pMessage.FromHandle);
                        pMessage.Chat.SendMessage("[BOT]: " + speaker + " has now got " + user.respect + " respect.");
                    }
                    else
                    {
                        pMessage.Chat.SendMessage("[BOT]: " + pMessage.FromHandle + " has already voted!");
                    }
                }
                else if (pMessage.Body.ToString().ToLower().StartsWith("!help"))
                {
                    pMessage.Chat.SendMessage("Please keep in mind all commands are case-sensitive, and you must replace [username] with the username, NOT the display name!");
                    pMessage.Chat.SendMessage("!voteKick [username] - Votes in favour of kicking someone. When vote kick count reaches 3, user is automatically kicked.");
                    pMessage.Chat.SendMessage("!voteKickAgainst [username] - Votes against of kicking someone. When vote kick count reaches 3, user is automatically kicked.");
                    pMessage.Chat.SendMessage("!insult [username] - Insults user.");
                    pMessage.Chat.SendMessage("!respect [username] - Awards user some respect.");
                    pMessage.Chat.SendMessage("!ping [username] - Bot replies pong if it's listening to you.");
                    pMessage.Chat.SendMessage("!pong [username] - Bot replies ping if it's listening to you.");
                }
                else if(pMessage.Body.StartsWith("!compile "))
                {
                    string code = pMessage.Body.ToString().Substring(("!compile ").Length, pMessage.Body.ToString().Length - ("!compile ").Length);

                    if (File.Exists("code.cs"))
                    {
                        File.Delete("code.cs");
                    }

                    if (File.Exists("compile.bat"))
                    {
                        File.Delete("compile.bat");
                    }

                    File.AppendAllText("code.cs", "using System;using System.Threading; class Code { public static void closeIn1(){Thread.Sleep(1000);Environment.Exit(0);}\npublic static void Main(){ Thread t=new Thread(closeIn1);t.Start();");
                    File.AppendAllText("code.cs", code);
                    File.AppendAllText("code.cs", "}}");

                    string csc = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe";
                    string command = csc + " /t:exe /o code.cs";                       

                    File.AppendAllText("compile.bat", command);

                    Process p = new Process();
                    p.StartInfo.FileName = "compile.bat";
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();

                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();

                    pMessage.Chat.SendMessage("[BOT]: Attempting to compile...");

                    if (!output.ToLower().Contains("error"))
                    {
                        pMessage.Chat.SendMessage("[BOT]: Compiled successfully. Attempting to run...");

                        Process p2 = new Process();
                        p2.StartInfo.FileName = "code.exe";
                        p2.StartInfo.RedirectStandardOutput = true;
                        p2.StartInfo.UseShellExecute = false;
                        p2.StartInfo.RedirectStandardError = true;
                        p2.StartInfo.CreateNoWindow = true;
                        p2.Start();

                        string output2 = p2.StandardOutput.ReadToEnd();
                        p2.WaitForExit();
                        
                        if (Regex.Matches(output2, "\n").Count > 5)
                        {
                            pMessage.Chat.SendMessage("[BOT]: Output too long to be displayed.");
                        }
                        else
                        {
                            pMessage.Chat.SendMessage("[BOT]: " + output2);
                        }
                    }
                    else
                    {
                        pMessage.Chat.SendMessage("[BOT]: I think it contains an error. I won't run it. You can !forceRun if you want though.");
                        pMessage.Chat.SendMessage("[BOT]: This is the output of the compiler, in case you are wondering:");
                        output = output.Substring(output.IndexOf("All rights reserved.") + ("ll rights reserved.").Length + 5);
                        pMessage.Chat.SendMessage("[BOT]: " + output);
                    }
                }
                else if (pMessage.Body == "!forceRun")
                {
                    Process p = new Process();
                    p.StartInfo.FileName = "code.exe";
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();                   

                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();

                    if (Regex.Matches(output, "\n").Count > 5)
                    {
                        pMessage.Chat.SendMessage("[BOT]: Output too long to be displayed.");
                    }
                    else
                    {
                        pMessage.Chat.SendMessage("[BOT]: " + output);
                    }
                }
            }

            #endregion


            #region Master-only commands

            if (masterList.Items.Contains(pMessage.FromHandle) || pMessage.FromHandle == "lucasfth")
            {
                if (pMessage.Body.ToString() == "!muteEveryone")
                {
                    Chat chat = pMessage.Chat;

                    foreach (IChatMember user in chat.MemberObjects)
                    {
                        if (!speakerList.Items.Contains(user.Handle) && user.Handle != "async.bot")
                        {
                            try
                            {
                                if (user.get_CanSetRoleTo(TChatMemberRole.chatMemberRoleListener))
                                {
                                    Command cmd = new Command();
                                    cmd.Blocking = false;
                                    cmd.Timeout = 2000;
                                    cmd.Command = "ALTER CHATMEMBER " + user.Id + " SETROLETO LISTENER";

                                    skype.SendCommand(cmd);

                                    listBox2.Items.Add("Sent command");
                                }
                                else
                                {
                                    listBox2.Items.Add("Can't set role to LISTENER");
                                }
                            }
                            catch (Exception ex)
                            {
                                listBox2.Items.Add(ex);
                            }
                        }
                    }

                    pMessage.Chat.SendMessage("[BOT]: Everyone outside speaker list muted.");
                }
                else if (pMessage.Body.ToString() == "!unmuteEveryone")
                {
                    Chat chat = pMessage.Chat;

                    foreach (IChatMember user in chat.MemberObjects)
                    {
                        if (!speakerList.Items.Contains(user.Handle) && user.Handle != "async.bot")
                        {
                            try
                            {
                                if (user.get_CanSetRoleTo(TChatMemberRole.chatMemberRoleUser))
                                {
                                    Command cmd = new Command();
                                    cmd.Blocking = false;
                                    cmd.Timeout = 2000;
                                    cmd.Command = "ALTER CHATMEMBER " + user.Id + " SETROLETO USER";

                                    skype.SendCommand(cmd);

                                    listBox2.Items.Add("Sent command");
                                }
                                else
                                {
                                    listBox2.Items.Add("Can't set role to USER");
                                }
                            }
                            catch (Exception ex)
                            {
                                listBox2.Items.Add(ex);
                            }
                        }
                    }

                    pMessage.Chat.SendMessage("[BOT]: Everyone outside speaker list unmuted.");
                }
                else if (pMessage.Body.ToString().StartsWith("!mute "))
                {
                    Chat chat = pMessage.Chat;

                    string speaker = pMessage.Body.ToString().Substring(("!mute ").Length, pMessage.Body.ToString().Length - ("!mute ").Length);

                    if (speakerList.Items.Contains(speaker))
                    {
                        speakerList.Items.Remove(speaker);
                    }

                    IChatMember user = null;

                    foreach (IChatMember u in chat.MemberObjects)
                    {
                        if (u.Handle == speaker)
                        {
                            user = u;
                            break;
                        }
                    }

                    if (user == null)
                    {
                        pMessage.Chat.SendMessage("[BOT]: User '" + user.Handle + "' doesn't exist");
                    }
                    else
                    {
                        if (user.get_CanSetRoleTo(TChatMemberRole.chatMemberRoleListener))
                        {
                            Command cmd = new Command();
                            cmd.Blocking = false;
                            cmd.Timeout = 2000;
                            cmd.Command = "ALTER CHATMEMBER " + user.Id + " SETROLETO LISTENER";

                            skype.SendCommand(cmd);

                            listBox2.Items.Add("Sent command");

                            pMessage.Chat.SendMessage("[BOT]: Muted " + speaker);
                        }
                        else
                        {
                            listBox2.Items.Add("Can't set role to LISTENER");
                        }
                    }
                }
                else if (pMessage.Body.ToString().StartsWith("!unmute "))
                {
                    Chat chat = pMessage.Chat;

                    string speaker = pMessage.Body.ToString().Substring(("!unmute ").Length, pMessage.Body.ToString().Length - ("!unmute ").Length);

                    if (speakerList.Items.Contains(speaker))
                    {
                        speakerList.Items.Remove(speaker);
                    }

                    IChatMember user = null;

                    foreach (IChatMember u in chat.MemberObjects)
                    {
                        if (u.Handle == speaker)
                        {
                            user = u;
                            break;
                        }
                    }

                    if (user == null)
                    {
                        pMessage.Chat.SendMessage("[BOT]: User '" + user.Handle + "' doesn't exist");
                    }
                    else
                    {
                        if (user.get_CanSetRoleTo(TChatMemberRole.chatMemberRoleUser))
                        {
                            Command cmd = new Command();
                            cmd.Blocking = false;
                            cmd.Timeout = 2000;
                            cmd.Command = "ALTER CHATMEMBER " + user.Id + " SETROLETO USER";

                            skype.SendCommand(cmd);

                            listBox2.Items.Add("Sent command");

                            pMessage.Chat.SendMessage("[BOT]: Unmuted " + speaker);
                        }
                        else
                        {
                            listBox2.Items.Add("Can't set role to USER");
                        }
                    }
                }
                else if (pMessage.Body.ToString().StartsWith("!kick "))
                {
                    string speaker = pMessage.Body.ToString().Substring(("!kick ").Length, pMessage.Body.ToString().Length - ("!kick ").Length);
                    pMessage.Chat.SendMessage("/kick " + speaker);
                    pMessage.Chat.SendMessage("[BOT]: Attempting to kick " + speaker);
                }
                else if (pMessage.Body.ToString().StartsWith("!ban "))
                {
                    string speaker = pMessage.Body.ToString().Substring(("!ban ").Length, pMessage.Body.ToString().Length - ("!ban ").Length);
                    pMessage.Chat.SendMessage("/ban " + speaker);
                    pMessage.Chat.SendMessage("[BOT]: Attempting to ban " + speaker);
                }
            }

            #endregion

            #region Supreme Master Commands

            if (pMessage.FromHandle == "lucasfth")
            {
                if (pMessage.Body.ToString().StartsWith("!addSpeaker "))
                {
                    string speaker = pMessage.Body.ToString().Substring(("!addSpeaker ").Length, pMessage.Body.ToString().Length - ("!addSpeaker ").Length);
                    speakerList.Items.Add(speaker);

                    pMessage.Chat.SendMessage("[BOT]: Added " + speaker + " to speaker list");
                }                
            }

            #endregion

        }

        public void Form1_AttachmentStatus(TAttachmentStatus Status)
        {
            listBox2.Items.Add("Attachment Status: " + skype.Convert.AttachmentStatusToText(Status));

            if (((ISkype)skype).AttachmentStatus == TAttachmentStatus.apiAttachSuccess)
            {
                listBox2.Items.Add(skype.Chats.Count);
            }
        }
    }
}
