<p align="left">
  <img src="https://upload.wikimedia.org/wikipedia/commons/b/b3/Logo_Image_Campus.png" alt="Image Campus" width="200"/>
</p>

# TP04_C1_BlancoRomero_RetroPong

### Itch.io
https://agustinlazaro.itch.io/
---

## Español

### Game details
Descripción breve del juego: 

### Cómo jugar
* **W / S** (o Flechas): Movimiento de la paleta

Explicación breve de las mecánicas principales
(rebotes, aceleración de la pelota, multiplicadores de velocidad, power-ups, etc.).

---

## English

### Game details
Brief description of the game: 

### How to play
* **W / S** (or Arrows): Paddle movement

Brief overview of the main mechanics 
(bounces, ball speed progression, power-ups, etc.).

---

### Desarrollado Por / By
Agustin Lazaro Blanco Romero

### Créditos / Credits
* **Sprites / Arte**: [kenney_ui-pack-adventure] https://kenney.nl/assets/ui-pack-adventure
* **Audio / SFX**: 
* **Fuentes**: [04b-30](https://www.dafont.com/es/04b-30.font)


////////////////////////////////////////////////////////////////////////////////////////////////////////


 ### Practical Assignment 1C No. 04


---CLASS 04---

*Basic Requirements*

- [✅] Include all mechanics from TP03
- [✅] Move all dynamic scene objects using physics (Rigidbody -> AddForce)
- [➖] Progressively increase ball speed over time or upon impact
- [➖] Code readability and standardization (variables, declarations, functions, and classes)
- [ ] Use Scriptable Objects for initialization variables
- [ ] Best-of-5 match (first to 3 goals wins), configurable via "GameSettings" Scriptable Object
- [ ] 20-second shot-clock limit to score (otherwise award goal against the side where the ball is), configurable via "GameSettings"
- [ ] Change paddle color to Black when hitting any screen boundary
- [ ] Change paddle color randomly when hitting the ball
- [ ] Add horizontal paddle movement (A/D and left/right arrows) bounded between midfield and goal line
- [ ] Define paddle behavior with Power-Ups (disable physical collisions or collect them on trigger)

*Advanced Requirements*

- [ ] Obstacle system spawning at random positions near the center
- [ ] Despawn obstacles between 3 and 7 seconds after spawning
- [ ] Power-Up spawn system (e.g., ball speed, paddle size, shields)
- [ ] Implement the "Object Pool" design pattern for spawners
