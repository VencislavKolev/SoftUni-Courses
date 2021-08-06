package udpChat;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;

public class MessageReceiver implements Runnable {
    DatagramSocket socket;
    byte[] buffer;

    public MessageReceiver(DatagramSocket socket) {
        this.socket = socket;
        this.buffer = new byte[1024];
    }

    @Override
    public void run() {
        while (true) {
            try {
                DatagramPacket packet = new DatagramPacket(this.buffer, this.buffer.length);
                this.socket.receive(packet);
                String received = new String(packet.getData(), 0, packet.getLength());
                System.out.println(received.trim());
            } catch (IOException e) {
                System.err.println(e.getMessage());
            }
        }
    }
}
