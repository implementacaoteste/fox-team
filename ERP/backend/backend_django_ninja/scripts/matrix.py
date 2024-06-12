import curses
import random
import time

def main(stdscr):
    # Ocultar o cursor
    curses.curs_set(0)
    
    # Pegar as dimensões da tela
    sh, sw = stdscr.getmaxyx()
    
    # Gerar uma lista de posições iniciais para as colunas de caracteres
    col_positions = [random.randint(0, sh - 1) for _ in range(sw)]
    
    while True:
        stdscr.clear()
        
        for x in range(sw):
            # Gerar um caractere aleatório
            char = chr(random.randint(33, 126))
            
            # Calcular a posição Y para a coluna atual
            y = col_positions[x]
            
            # Desenhar o caractere na posição
            stdscr.addstr(y, x, char, curses.color_pair(1))
            
            # Atualizar a posição Y para a coluna atual
            col_positions[x] = (y + 1) % sh
        
        stdscr.refresh()
        time.sleep(0.10)

if __name__ == "__main__":
    # Inicializar a cor
    curses.initscr()
    curses.start_color()
    curses.init_pair(1, curses.COLOR_GREEN, curses.COLOR_BLACK)
    
    # Executar a função principal
    curses.wrapper(main)