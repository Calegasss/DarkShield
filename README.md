# Dark Shield

**Dark Shield** é um jogo 2D desenvolvido em **Unity** e **C#**, criado originalmente em meados de 2023 como meu principal projeto para apresentação no **Mundo SENAI**.

Na época, tive cerca de quatro semanas para aprender a base da Unity, desenvolver um jogo de teste e, em seguida, construir este projeto principal. O jogo nasceu como uma experiência de aprendizado, mas também como uma homenagem aos RPGs e jogos de ação que me inspiravam, como **Elden Ring**, **Dark Souls** e **The Elder Scrolls**.

Mesmo sendo um projeto acadêmico, Dark Shield marcou bastante minha trajetória. Ele foi apresentado no Mundo SENAI para estudantes de diversas escolas e representa uma fase importante do meu desenvolvimento como programador, principalmente por ter sido uma das minhas primeiras experiências mais completas com desenvolvimento de jogos, lógica em C#, cenas, animações, colisões, interface e build WebGL.

## Jogar online

O jogo está preparado para rodar pelo GitHub Pages:

`https://calegasss.github.io/DarkShield/`

> Caso o link ainda não esteja disponível, é necessário ativar o GitHub Pages nas configurações do repositório, usando a branch `main` e a pasta `/docs`.

## Tecnologias utilizadas

- Unity
- C#
- WebGL
- GitHub Pages
- Tilemaps
- UI da Unity
- Animações 2D
- Sistema de cenas

## Estrutura do projeto

- `Dark Shield/`: projeto Unity editável
- `docs/`: build WebGL publicado pelo GitHub Pages
- `docs/index.html`: página responsável por carregar o jogo no navegador
- `docs/Build/`: arquivos gerados pelo build WebGL
- `docs/TemplateData/`: arquivos visuais do template WebGL da Unity

## Sobre o jogo

Dark Shield é um jogo 2D de ação e aventura com inspiração em universos de fantasia sombria. O projeto possui movimentação, pulo, rolagem, ataque, cenas diferentes, inimigos, boss, interface e progressão entre áreas.

A proposta original era criar uma experiência jogável que demonstrasse aprendizado em desenvolvimento de jogos dentro de um curto período de tempo, unindo programação, design de fases, animações e apresentação visual.

## Comandos

- `A` / `D` ou setas: mover
- `Espaço`: pular
- `R`: rolar
- `F`: atacar
- `E`: interagir com elementos como fogueiras e jarros
- `W`: entrar em portas

## Retomada do projeto

Com carinho e admiração por este projeto, estou retomando o Dark Shield com o objetivo de aplicar o conhecimento que adquiri desde sua criação. A ideia não é apagar sua essência original, mas evoluí-lo com ajustes finos, melhorias técnicas e patches de atualização.

Dark Shield representa meu começo no desenvolvimento de jogos e agora também representa minha evolução técnica.

## Roadmap

### v0.1 - Preservação do projeto original

- Manter o build WebGL jogável no GitHub Pages
- Documentar o contexto histórico do projeto
- Organizar README, imagens e instruções

### v0.2 - Correções técnicas

- Corrigir vida inicial do jogador
- Implementar dano real no ataque do player
- Implementar dano real dos inimigos e boss
- Remover scripts vazios ou obsoletos
- Revisar nomes de arquivos e classes

### v0.3 - Gameplay polish

- Melhorar movimentação
- Ajustar rolagem, pulo e ataque
- Melhorar feedback visual de dano
- Revisar colisões e hitboxes
- Balancear dificuldade

### v0.4 - Interface e experiência

- Melhorar menu inicial
- Melhorar tela de comandos
- Adicionar tela de pausa
- Melhorar tela de game over
- Ajustar responsividade do WebGL

### v1.0 - Dark Shield Remastered

- Build estável
- README completo
- Página de apresentação
- Trailer ou GIF demonstrativo
- Versão final jogável no navegador

## Publicação

O build WebGL da pasta `docs/` utiliza arquivos não comprimidos para funcionar melhor no GitHub Pages sem exigir configuração personalizada de headers no servidor.

O export WebGL bruto na raiz do projeto é ignorado pelo Git. A versão compatível com o GitHub Pages fica centralizada na pasta `docs/`.

## Status

Projeto em retomada para ajustes finos, correções técnicas e futuras atualizações.
