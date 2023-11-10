#language: pt-br
Funcionalidade: Buscar postagens blog

Cenário: Validar exibição do ícone de buscar
    Dado que eu esteja na página do blog agibank
    Então devo ver o ícone de buscar
    
Cenário: Validar exibição do input de busca
    Dado que eu esteja na página do blog agibank
    Então devo ver o ícone de buscar
    Quando clico no ícone de buscar
    Então devo ver o campo de busca
    
Cenário: Validar exibição do botão pesquisar
    Dado que eu esteja na página do blog agibank
    Então devo ver o ícone de buscar
    Quando clico no ícone de buscar
    Então devo ver o botão pesquisar    
    
Cenário: Validar exibição de resultados ao clicar no botão pesquisar
    Dado que eu esteja na página do blog agibank
    Então devo ver o ícone de buscar
    Quando clico no ícone de buscar
    Então devo ver o botão pesquisar
    Quando clico no botão "Pesquisar"
    Então devo ver a lista de resultados
    
Cenário: Validar exibição de resultados de uma pesquisa específica ao clicar no botão pesquisar
    Dado que eu esteja na página do blog agibank
    Então devo ver o ícone de buscar
    Quando clico no ícone de buscar
    Então devo ver o botão pesquisar
    Quando preencho o campo pesquisar com o valor "cartão"
    E clico no botão "Pesquisar"
    Então devo ver a lista de resultados
