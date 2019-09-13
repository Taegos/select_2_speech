using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using Select2Speech.Properties;
using System.Windows.Forms;
using Select2Speech.Controllers;
using Select2Speech.Options;

namespace Select2Speech.SystemTray {

    /// <summary>
    /// The view for the system tray icon
    /// </summary>
    public class SystemTrayView {
        private NotifyIcon notifyIcon;
        private SystemTrayController controller;

        /// <summary>
        /// Initializes the notify icon in the system tray and.
        /// </summary>
        public SystemTrayView() {
            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            notifyIcon.Icon = Properties.Resources.Select2SpeechApp;
        }

        public void SetController(SystemTrayController controller)
        {
            this.controller = controller;
            notifyIcon.Click += (sender, args) => { controller.Open(); };
        }

        public void Load(string[] installedVoices)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            if (installedVoices.Length > 0)
            {
                foreach (string installedVoice in installedVoices)
                {
                    ToolStripMenuItem voiceItem = new ToolStripMenuItem(installedVoice);
                    voiceItem.Click += VoiceClicked;
                    contextMenuStrip.Items.Add(voiceItem);
                }
            }
            ToolStripMenuItem settingsItem = new ToolStripMenuItem("Settings");
            settingsItem.Click += SettingsClicked;
            contextMenuStrip.Items.Add(settingsItem);
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");
            exitItem.Click += ExitClicked;
            contextMenuStrip.Items.Add(exitItem);
            notifyIcon.ContextMenuStrip = contextMenuStrip;
        }

        public void SetMenuItemChecked(string targetText, bool value)
        {
            foreach (ToolStripMenuItem item in notifyIcon.ContextMenuStrip.Items)
            {
                if (item.Text == targetText)
                {
                    item.Checked = value;
                }
            }
        }

        public void Dispose()
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ExitClicked(object sender, EventArgs args) {
            controller.Exit();
        }

        /// <summary>
        /// Open the options form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SettingsClicked(object sender, EventArgs args) {
            controller.OpenSettings();
        }

        private void VoiceClicked(object sender, EventArgs args)
        {
            ToolStripMenuItem item = (ToolStripMenuItem) sender;
            controller.SetVoice(item.Text);
        }
    }
}
