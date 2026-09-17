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


Yes. In Windows 95, it is useful to distinguish between EXE programs, DLLs, virtual memory, 16-bit segments, and 32-bit modules, because the model was hybrid.

1. The main libraries available to a program

For a typical Win32 program, the simplified chain was:

YOURPROGRAM.EXE
               │
               ▼
          KERNEL32.DLL
               │
        ┌──────┴──────┐
        ▼             ▼
     USER32.DLL    GDI32.DLL
        │             │
        └──────┬──────┘
               ▼
        USER/GDI internally
               │
               ▼
        Drivers / VxDs / hardware

The most important DLLs included:

KERNEL32.DLL — fundamental services: memory, files, processes, threads, synchronization, etc.

USER32.DLL — windows, messages, keyboard, mouse, menus, controls, and interface.

GDI32.DLL — 2D graphics, fonts, bitmaps, drawing.

ADVAPI32.DLL — more advanced services, such as the Registry and security.

SHELL32.DLL — shell/Explorer functionality.

COMDLG32.DLL — common dialog boxes, such as Open/Save.

OLE32.DLL / OLEAUT32.DLL — OLE/COM and automation.

These were shared DLLs. The program did not need to have a physical copy of each library inside its EXE.

---

2. The EXE and DLLs in memory

Imagine you have:

MYPROG.EXE
    │
    ├── calls CreateFile()
    ├── calls CreateWindow()
    └── calls BitBlt()

During loading, Windows checks which DLLs are required.

For example:

MYPROG.EXE
     │
     ├──────────► KERNEL32.DLL
     │
     ├──────────► USER32.DLL
     │
     └──────────► GDI32.DLL

Each DLL was loaded as a module into the process's address space.  A conceptual simplification would be:

Process address space
┌──────────────────────────────┐
│ MEUPROG.EXE                  │
│ code + data                  │
├──────────────────────────────┤
│ KERNEL32.DLL                 │
│ code + data                  │
├──────────────────────────────┤
│ USER32.DLL                   │
│ code + data                  │
├──────────────────────────────┤
│ GDI32.DLL                    │
│ code + data                  │
├──────────────────────────────┤
│ other DLLs                   │
├──────────────────────────────┤
│ heap                         │
├──────────────────────────────┤
│ stack                        │
└──────────────────────────────┘

This is a simplification, because Windows 95 had specific details regarding mapping, segments, and shared memory.


---

3. DLL code could be shared

Here is a very important concept.

If you had:

PROGRAMA_A.EXE ──► USER32.DLL
PROGRAMA_B.EXE ──► USER32.DLL
PROGRAMA_C.EXE ──► USER32.DLL

it wasn't necessary to keep three physical copies of the USER32.DLL code in RAM.

The system could share code pages across processes.

Conceptually:

RAM
              │
       ┌──────▼───────┐
       │ USER32 code  │
       └──────┬───────┘
              │
       ┌──────┼─────────────┐
       │      │             │
       ▼      ▼             ▼
    Proc A  Proc B       Proc C

Each process had its own view/address of the library, but the code could be physically shared.

Modifiable data was another matter: you can't simply let all processes write to the same global data.


---
4. How was a DLL function located?

An EXE contained information about the DLLs it depended on.

For example, conceptually:

MEUPROG.EXE
   │
   └── USER32.DLL
          │
          └── CreateWindowEx

The loader would look for the DLL and then resolve references to the functions.

For instance, your program had something equivalent to:

CreateWindowEx(...);

The compiled code did not need to contain a copy of the CreateWindowEx implementation.

The loader linked the program's reference to the function existing within the DLL.

This is a form of dynamic linking.


---

5. What happened when you ran an EXE?

Let's imagine:

C:\WINDOWS\NOTEPAD.EXE

When you double-clicked it:

Step 1 — the Shell asks the system to execute the EXE

Explorer/the Shell requests the creation of the process.

Step 2 — the loader identifies the format

Windows 95 could handle different executable formats, namely:

NE — New Executable, used by 16-bit Windows;

PE — Portable Executable, used by Win32 programs.


This is extremely important for understanding Windows 95.

Step 3 — the address space is created

For a Win32 program, the system prepares the process's virtual address space.

Step 4 — the EXE is mapped

The EXE's code and data are placed/mapped into the address space.

Conceptually:

Process
│
├── EXE
│   ├── code
│   ├── data
│   └── resources
│
├── DLL
│
├── DLL
│
├── heap
│
└── stack

Step 5 — dependent DLLs are loaded

If the EXE says:

I need KERNEL32.DLL
I need USER32.DLL
I need GDI32.DLL

the loader handles those dependencies.  And a DLL can depend on another:

MEUPROG.EXE
    │
    ├── KERNEL32.DLL
    │       └── another DLL
    │
    ├── USER32.DLL
    │
    └── GDI32.DLL

The loader therefore has a sort of dependency tree/graph.


---
