import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;

public class PaintApp extends JFrame {
    private BufferedImage canvas;
    private Graphics2D g2d;
    private int prevX, prevY;

    public PaintApp() {
        setTitle("Paint em Java");
        setSize(800, 600);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        // Criar canvas
        canvas = new BufferedImage(800, 600, BufferedImage.TYPE_INT_ARGB);
        g2d = canvas.createGraphics();
        g2d.setColor(Color.YELLOW);
        g2d.fillRect(0, 0, 800, 600); // fundo amarelo
        g2d.setColor(Color.BLACK); // cor padrão do pincel

        // Painel para desenhar
        JPanel drawPanel = new JPanel() {
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(canvas, 0, 0, null);
            }
        };

        drawPanel.addMouseListener(new MouseAdapter() {
            public void mousePressed(MouseEvent e) {
                prevX = e.getX();
                prevY = e.getY();
            }
        });

        drawPanel.addMouseMotionListener(new MouseMotionAdapter() {
            public void mouseDragged(MouseEvent e) {
                int currX = e.getX();
                int currY = e.getY();
                g2d.drawLine(prevX, prevY, currX, currY);
                prevX = currX;
                prevY = currY;
                drawPanel.repaint();
            }
        });

        // Menu de opções
        JMenuBar menuBar = new JMenuBar();
        JMenu menu = new JMenu("Opções");

        JMenuItem limpar = new JMenuItem("Limpar");
        limpar.addActionListener(e -> {
            g2d.setColor(Color.WHITE);
            g2d.fillRect(0, 0, 800, 600);
            g2d.setColor(Color.BLACK);
            drawPanel.repaint();
        });

        JMenuItem mudarCor = new JMenuItem("Mudar Cor");
        mudarCor.addActionListener(e -> {
            Color novaCor = JColorChooser.showDialog(null, "Escolher cor", g2d.getColor());
            if (novaCor != null) {
                g2d.setColor(novaCor);
            }
        });

        menu.add(mudarCor);
        menu.add(limpar);
        menuBar.add(menu);
        setJMenuBar(menuBar);

        add(drawPanel);
        setVisible(true);
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(PaintApp::new);
    }
}
