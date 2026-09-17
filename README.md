Ele foi um sistema híbrido, combinando código de 16 e 32 bits, e marcou uma grande transição da arquitetura MS-DOS/Windows 3.x para um ambiente mais moderno.
 Podemos entender o Windows 95 através de várias camadas, do nível mais baixo ao mais alto:

 1. Ferragens

 É a camada física:

 CPU (Intel 80386/80486/Pentium, por exemplo)

 BATER

 disco rígido

 placa gráfica

 teclado, rato, etc.

 O Windows 95 precisa de lidar com hardware muito variado através de seus drivers.

 2. BIOS e firmware

 A BIOS fazia a inicialização do computador e disponibilizava serviços básicos para o sistema operacional, como a detecção de hardware e a inicialização.

 3.MS-DOS

 Aqui está uma das características mais importantes do Windows 95.
 O Windows 95 depende do MS-DOS para arrancar.  Durante o processo de inicialização, o DOS carregava primeiro e depois o Windows assumia o controle.
 Por isso, dizer simplesmente que o Windows 95 era um sistema operativo de 32 bits é uma simplificação.

 4. Drivers e acesso ao hardware

 O Windows 95 modificou uma arquitetura de drivers mais moderna, incluindo o VxD (Virtual Device Driver).
 Os VxDs permitem ao sistema controlar dispositivos e recursos como:

 memória;

 discotecas;

 placas de som;

 placas de rede;

 dispositivos PCI.

 Eles funcionavam em camadas bastante privilegiadas do sistema.

 5. Kernel e componentes do sistema de 32 bits

 Esta é uma das grandes novidades.
 O Windows 95 tem vários componentes dinâmicos de 32 bits, capazes de tirar partido dos econômicos 386 e superiores.
 Entre eles estavam componentes relacionados com:

 gestão de memória;

 processos e threads;

 sistema de arquivos;

 dispositivos;

 comunicação entre aplicações.

 Contudo, ainda existiam componentes importantes de 16 bits, herdados da arquitetura anterior.

 6.Win32

 A API Win32 fornece às aplicações uma interface de programação de 32 bits.
 Por exemplo, um programa poderia pedir ao Windows para:

 criar uma janela;

 abrir um arquivo;

 reservar memória;

 criar um tópico;

 comunicar com outro componente do sistema.

 Isto permitiu que surgisse uma nova geração de aplicações Windows de 32 bits.

 7. Subsistemas de compatibilidade de 16 bits

 Para manter a compatibilidade com o enorme número de programas existentes para Windows 3.x, o Windows 95 ainda precisa de executar software de 16 bits.
 Assim, coexistiam:
 Aplicativos 32 bits → Win32 → componentes do sistema
 e
 Aplicações 16 bits → mecanismos de compatibilidade → componentes antigos
 Essa compatibilidade é uma das razões pelas quais a arquitetura do Windows 95 parece bastante complicada.

 8. Shell gráficos

 No topo estava a interface que o usuário via.
 O Windows 95 dinâmico o famoso:
 Área de Trabalho → Iniciar → Programas → Barra de Tarefas → Explorer
 O Windows Explorer tornou-se uma peça central da experiência do sistema.

 Resumindo

 Uma representação simplificada seria:
 ┌─────────────────────────────┐ │ Aplicações Windows │  ├─────────────────────────────┤ │ API Win32 │  ├─────────────────────────────┤ │ Shell / Explorer / GUI │  ├─────────────────────────────┤ │ Componentes do Windows 95 │ │ 32 bits +  16 bits │ ├─────────────────────────────┤ │ Drivers / VxDs │  ├─────────────────────────────┤ │ MS-DOS │  ├─────────────────────────────┤ │ BIOS / Firmware │  ├─────────────────────────────┤ │ Hardware │  └─────────────────────────────┘
