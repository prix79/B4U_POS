// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 06-18-2008
// ***********************************************************************
// <copyright file="StatusAPI.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text;
using System.Runtime.InteropServices;

/// <summary>
/// Class StatusAPI.
/// </summary>
class StatusAPI
{
    /// <summary>
    /// The success
    /// </summary>
    public const int SUCCESS = 0;

    //BiOpenMonPrinter Argument
    /// <summary>
    /// The type port
    /// </summary>
    public const int TYPE_PORT = 1;
    /// <summary>
    /// The type printer
    /// </summary>
    public const int TYPE_PRINTER = 2;

    //BiOpenDrawer Argument
    /// <summary>
    /// The eps bi drawer 1
    /// </summary>
    public const byte EPS_BI_DRAWER_1 = 1;
    /// <summary>
    /// The eps bi drawer 2
    /// </summary>
    public const byte EPS_BI_DRAWER_2 = 2;

    /// <summary>
    /// The eps bi pulse 100
    /// </summary>
    public const byte EPS_BI_PULSE_100 = 1;
    /// <summary>
    /// The eps bi pulse 200
    /// </summary>
    public const byte EPS_BI_PULSE_200 = 2;
    /// <summary>
    /// The eps bi pulse 300
    /// </summary>
    public const byte EPS_BI_PULSE_300 = 3;
    /// <summary>
    /// The eps bi pulse 400
    /// </summary>
    public const byte EPS_BI_PULSE_400 = 4;
    /// <summary>
    /// The eps bi pulse 500
    /// </summary>
    public const byte EPS_BI_PULSE_500 = 5;
    /// <summary>
    /// The eps bi pulse 600
    /// </summary>
    public const byte EPS_BI_PULSE_600 = 6;
    /// <summary>
    /// The eps bi pulse 700
    /// </summary>
    public const byte EPS_BI_PULSE_700 = 7;
    /// <summary>
    /// The eps bi pulse 800
    /// </summary>
    public const byte EPS_BI_PULSE_800 = 8;

    //Printer Status
    /// <summary>
    /// The asb no response
    /// </summary>
    public const int ASB_NO_RESPONSE = 0x1;              // No response
    /// <summary>
    /// The asb print success
    /// </summary>
    public const int ASB_PRINT_SUCCESS = 0x2;            // Finish to print
    /// <summary>
    /// The asb unrecover error
    /// </summary>
    public const int ASB_UNRECOVER_ERR = 0x2000;         // Unrecoverable error
    /// <summary>
    /// The asb autorecover error
    /// </summary>
    public const int ASB_AUTORECOVER_ERR = 0x4000;       // Auto-Recoverable error
    /// <summary>
    /// The asb off line
    /// </summary>
    public const int ASB_OFF_LINE = 0x8;                 // Off-line
    /// <summary>
    /// The asb wait on line
    /// </summary>
    public const int ASB_WAIT_ON_LINE = 0x100;           // Waiting for on-line recovery
    /// <summary>
    /// The asb panel switch
    /// </summary>
    public const int ASB_PANEL_SWITCH = 0x200;           // Panel switch
    /// <summary>
    /// The asb printer feed
    /// </summary>
    public const int ASB_PRINTER_FEED = 0x40;            // Paper is being fed by using the PAPER FEED button
    /// <summary>
    /// The asb mechanical error
    /// </summary>
    public const int ASB_MECHANICAL_ERR = 0x400;         // Mechanical error
    /// <summary>
    /// The asb autocutter error
    /// </summary>
    public const int ASB_AUTOCUTTER_ERR = 0x800;         // Auto cutter error
    /// <summary>
    /// The asb drawer kick
    /// </summary>
    public const int ASB_DRAWER_KICK = 0x4;              // Drawer kick-out connector pin3 is HIGH
    /// <summary>
    /// The asb journal end
    /// </summary>
    public const int ASB_JOURNAL_END = 0x40000;          // Journal paper roll end
    /// <summary>
    /// The asb receipt end
    /// </summary>
    public const int ASB_RECEIPT_END = 0x80000;          // Receipt paper roll end
    /// <summary>
    /// The asb cover open
    /// </summary>
    public const int ASB_COVER_OPEN = 0x20;              // Cover is open
    /// <summary>
    /// The asb journal near end
    /// </summary>
    public const int ASB_JOURNAL_NEAR_END = 0x10000;     // Journal paper roll near-end
    /// <summary>
    /// The asb receipt near end
    /// </summary>
    public const int ASB_RECEIPT_NEAR_END = 0x20000;     // Receipt paper roll near-end
    /// <summary>
    /// The asb slip tof
    /// </summary>
    public const int ASB_SLIP_TOF = 0x200000;            // SLIP TOF
    /// <summary>
    /// The asb slip bof
    /// </summary>
    public const int ASB_SLIP_BOF = 0x400000;            // SLIP BOF
    /// <summary>
    /// The asb slip selected
    /// </summary>
    public const int ASB_SLIP_SELECTED = 0x1000000;      // Slip is not Selected
    /// <summary>
    /// The asb print slip
    /// </summary>
    public const int ASB_PRINT_SLIP = 0x2000000;         // Cannot print on slip
    /// <summary>
    /// The asb validation selected
    /// </summary>
    public const int ASB_VALIDATION_SELECTED = 0x4000000;    // Validation is not selected
    /// <summary>
    /// The asb print validation
    /// </summary>
    public const int ASB_PRINT_VALIDATION = 0x8000000;   // Cannot print on validation
    /// <summary>
    /// The asb validation tof
    /// </summary>
    public const int ASB_VALIDATION_TOF = 0x20000000;    // Validation TOF
    /// <summary>
    /// The asb validation bof
    /// </summary>
    public const int ASB_VALIDATION_BOF = 0x40000000;    // Validation BOF
    /// <summary>
    /// The ink asb near end
    /// </summary>
    public const int INK_ASB_NEAR_END = 0x1;             // Ink near-end
    /// <summary>
    /// The ink asb end
    /// </summary>
    public const int INK_ASB_END = 0x2;                  // Ink end
    /// <summary>
    /// The ink asb no cartridge
    /// </summary>
    public const int INK_ASB_NO_CARTRIDGE = 0x4;         // Cartridge is not present
    /// <summary>
    /// The ink asb cleaning
    /// </summary>
    public const int INK_ASB_CLEANING = 0x20;            // Being cleaned
    /// <summary>
    /// The ink asb near en d2
    /// </summary>
    public const int INK_ASB_NEAR_END2 = 0x100;          // Ink near-end2
    /// <summary>
    /// The ink asb en d2
    /// </summary>
    public const int INK_ASB_END2 = 0x200;               // Ink end2
    /// <summary>
    /// The asb presenter cover
    /// </summary>
    public const int ASB_PRESENTER_COVER = 0x4;          // Presenter cover is open
    /// <summary>
    /// The asb platen open
    /// </summary>
    public const int ASB_PLATEN_OPEN = 0x20;             // Platen is open
    /// <summary>
    /// The asb journal near end first
    /// </summary>
    public const int ASB_JOURNAL_NEAR_END_FIRST = 0x10000;   // Journal paper roll near-end-first
    /// <summary>
    /// The asb receipt near end first
    /// </summary>
    public const int ASB_RECEIPT_NEAR_END_FIRST = 0x20000;   // Paper low (First)
    /// <summary>
    /// The asb psupplier end
    /// </summary>
    public const int ASB_PSUPPLIER_END = 0x200000;       // Paper suppliyer end
    /// <summary>
    /// The asb receipt near end second
    /// </summary>
    public const int ASB_RECEIPT_NEAR_END_SECOND = 0x400000; // Receipt paper roll near-end-second
    /// <summary>
    /// The asb presenter te
    /// </summary>
    public const int ASB_PRESENTER_TE = 0x1000000;       // Presenter T/E receipt end
    /// <summary>
    /// The asb presenter tt
    /// </summary>
    public const int ASB_PRESENTER_TT = 0x2000000;       // Presenter T/T receipt end
    /// <summary>
    /// The asb retractor r1 jam
    /// </summary>
    public const int ASB_RETRACTOR_R1JAM = 0x4000000;    // Presenter receipt end R1JAM
    /// <summary>
    /// The asb retractor box
    /// </summary>
    public const int ASB_RETRACTOR_BOX = 0x8000000;      // Retractor box
    /// <summary>
    /// The asb retractor r2 jam
    /// </summary>
    public const int ASB_RETRACTOR_R2JAM = 0x20000000;   // Retractor receipt end R2JAM
    /// <summary>
    /// The asb retractor senso r3
    /// </summary>
    public const int ASB_RETRACTOR_SENSOR3 = 0x40000000; // Receipt end retractor box
    /// <summary>
    /// The asb battery offline
    /// </summary>
    public const int ASB_BATTERY_OFFLINE = 0x4;          // Off-line for BATTERY QUANTITY(3.01)
    /// <summary>
    /// The asb paper feed
    /// </summary>
    public const int ASB_PAPER_FEED = 0x40;              // Paper is now feeding by PF FW (3.01)
    /// <summary>
    /// The asb paper end first
    /// </summary>
    public const int ASB_PAPER_END_FIRST = 0x40000;      // Detected paper roll end first (3.01)
    /// <summary>
    /// The asb paper end second
    /// </summary>
    public const int ASB_PAPER_END_SECOND = 0x80000;     // Detected paper roll end second (3.01)

    /// <summary>
    /// Bis the open mon printer.
    /// </summary>
    /// <param name="nType">Type of the n.</param>
    /// <param name="pName">Name of the p.</param>
    /// <returns>Int32.</returns>
    [DllImport("EpsStmApi.dll", EntryPoint = "BiOpenMonPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern Int32 BiOpenMonPrinter(int nType, String pName);

    /// <summary>
    /// Bis the open drawer.
    /// </summary>
    /// <param name="nHandle">The n handle.</param>
    /// <param name="drawer">The drawer.</param>
    /// <param name="pulse">The pulse.</param>
    /// <returns>Int32.</returns>
    [DllImport("EpsStmApi.dll", EntryPoint = "BiOpenDrawer", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern Int32 BiOpenDrawer(Int32 nHandle, byte drawer, byte pulse);

    /// <summary>
    /// Bis the set status back function.
    /// </summary>
    /// <param name="nHandle">The n handle.</param>
    /// <param name="pStatusCB">The p status cb.</param>
    /// <returns>Int32.</returns>
    [DllImport("EpsStmApi.dll", EntryPoint = "BiSetStatusBackFunction", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern Int32 BiSetStatusBackFunction(Int32 nHandle, StatusMonitoring pStatusCB);

    /// <summary>
    /// Bis the set status back WND.
    /// </summary>
    /// <param name="nHandle">The n handle.</param>
    /// <param name="hWnd">The h WND.</param>
    /// <param name="lpStatus">The lp status.</param>
    /// <returns>Int32.</returns>
    [DllImport("EpsStmApi.dll", EntryPoint = "BiSetStatusBackWnd", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern Int32 BiSetStatusBackWnd(Int32 nHandle, Int32 hWnd, Int32 lpStatus); //lpStatus is ByRef in vb.net -> will be IntPtr?

    /// <summary>
    /// Bis the reset printer.
    /// </summary>
    /// <param name="nHandle">The n handle.</param>
    /// <returns>Int32.</returns>
    [DllImport("EpsStmApi.dll", EntryPoint = "BiResetPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern Int32 BiResetPrinter(Int32 nHandle);

    /// <summary>
    /// Bis the cancel error.
    /// </summary>
    /// <param name="nHandle">The n handle.</param>
    /// <returns>Int32.</returns>
    [DllImport("EpsStmApi.dll", EntryPoint = "BiCancelError", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern Int32 BiCancelError(Int32 nHandle);

    /// <summary>
    /// Bis the cancel status back.
    /// </summary>
    /// <param name="nHandle">The n handle.</param>
    /// <returns>Int32.</returns>
    [DllImport("EpsStmApi.dll", EntryPoint = "BiCancelStatusBack", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern Int32 BiCancelStatusBack(Int32 nHandle);

    /// <summary>
    /// Bis the close mon printer.
    /// </summary>
    /// <param name="nHandle">The n handle.</param>
    /// <returns>Int32.</returns>
    [DllImport("EpsStmApi.dll", EntryPoint = "BiCloseMonPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
	public static extern Int32 BiCloseMonPrinter(Int32 nHandle);

    //
    //Delegate function declarations for Callback functions used by the program:
    //

    /// <summary>
    /// Delegate StatusMonitoring
    /// </summary>
    /// <param name="dwStatus">The dw status.</param>
    /// <returns>Int32.</returns>
    public delegate Int32 StatusMonitoring(int dwStatus);

}
