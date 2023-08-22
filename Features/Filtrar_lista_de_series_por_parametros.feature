#language: pt-br
Funcionalidade: Filtrar lista de séries por parâmetros

    Cenário: Exibir todos os campos de filtro de consulta
        Dado que eu esteja na página inicial
        Quando eu logo na aplicação
        Então devo ver a tela inicial do sistema
        E ver todos os campos de filtros

    Cenário: Limpar valores dos filtros na consulta
        Dado que eu esteja na página inicial
        Quando eu logo na aplicação
        Então devo ver a tela inicial do sistema
        E ver todos os campos de filtros
        Quando seleciono a opção "OBJETO 1" no campo "Objeto"
        Então devo ver a opção "SIN" no campo "Agregação espacial"
        Quando seleciono a opção "SUBSISTEMA NORTE" no campo "Subsistema"
        Então devo ver a opção "SUBSISTEMA NORTE" no campo "Subsistema"
        Quando seleciono a opção "BACIA DO RIO ARAGUARI" no campo "Bacia"
        Então devo ver a opção "BACIA DO RIO ARAGUARI" no campo "Bacia"
        Quando seleciono a opção "RIO ABAETE" no campo "Rio"
        Então devo ver a opção "RIO ABAETE" no campo "Rio"
        Quando clico no botão "Limpar filtros"
        Então devo ver os filtros limpos
