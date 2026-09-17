It was a hybrid system, combining 16-bit and 32-bit code, and marked a major transition from the MS-DOS/Windows 3.x architecture to a more modern environment.
We can understand Windows 95 through several layers, from the lowest to the highest level:

1. Hardware

This is the physical layer:

CPU (Intel 80386/80486/Pentium, for example)

RAM

Hard drive

Graphics card

Keyboard, mouse, etc.

Windows 95 had to handle a wide variety of hardware through its drivers.

2. BIOS and firmware

The BIOS handled computer startup and provided basic services to the operating system, such as hardware detection and initialization.

3. MS-DOS

This is one of the most important characteristics of Windows 95.
Windows 95 relied on MS-DOS to boot up. During the startup process, DOS loaded first, and then Windows took control.
Therefore, simply calling Windows 95 a 32-bit operating system is an oversimplification.

4. Drivers and hardware access

Windows 95 introduced a more modern driver architecture, including VxDs (Virtual Device Drivers).
VxDs allowed the system to control devices and resources such as:

memory;

disk drives;

sound cards;

network cards;

PCI devices.

They operated at highly privileged system levels.

5. Kernel and 32-bit system components

This was one of the major new features.
Windows 95 featured various dynamic 32-bit components capable of taking advantage of the 386 processor (and its successors).
These included components related to:

memory management;

processes and threads;

file systems;

devices;

inter-application communication.

However, important 16-bit components inherited from the previous architecture still existed.  6. Win32

The Win32 API provides applications with a 32-bit programming interface.
For example, a program could ask Windows to:

create a window;

open a file;

allocate memory;

create a thread;

communicate with another system component.

This enabled the emergence of a new generation of 32-bit Windows applications.

7. 16-bit compatibility subsystems

To maintain compatibility with the vast number of existing programs for Windows 3.x, Windows 95 still needed to run 16-bit software.
Thus, the following coexisted:
32-bit applications → Win32 → system components
and
16-bit applications → compatibility mechanisms → legacy components
This compatibility is one of the reasons why the Windows 95 architecture appears quite complex.

8. Graphical Shell

At the top was the interface seen by the user.
Windows 95 featured the famous:
Desktop → Start → Programs → Taskbar → Explorer
Windows Explorer became a central part of the system experience.

Summary

A simplified representation would be:
┌─────────────────────────────┐ │ Windows Applications │  ├─────────────────────────────┤ │ Win32 API │  ├─────────────────────────────┤ │ Shell / Explorer / GUI │  ├─────────────────────────────┤ │ Windows 95 Components │ │ 32-bit + 16-bit │ ├─────────────────────────────┤ │ Drivers / VxDs │  ├─────────────────────────────┤ │ MS-DOS │  ├─────────────────────────────┤ │ BIOS / Firmware │  ├─────────────────────────────┤ │ Hardware │  └─────────────────────────────┘
