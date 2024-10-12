namespace StockMaster.Domain.Enums;

public enum MovementReason
{
    Sale,       // Venda de produtos
    Loss,       // Perda de estoque (danificado, expirado, etc.)
    Restock,    // Reposição de estoque
    Adjustment  // Ajuste manual (erros, correções, etc.)
}
