﻿namespace Flappy_Bird_Windows;

partial class PipeTop
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(PipeTop));
        SuspendLayout();
        // 
        // PipeTop
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImage = Properties.Resources.pipe_green_top;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(124, 712);
        DoubleBuffered = true;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PipeTop";
        StartPosition = FormStartPosition.Manual;
        TopMost = true;
        ResumeLayout(false);
    }

    #endregion
}