import { CdiResponseDTO } from "../../types/CdiResponseDTO";
export function AdaptToPt_BR(response: CdiResponseDTO): CdiResponseDTO {
    const formatNumber = new Intl
        .NumberFormat('pt-BR', { style: "currency", currency: "BRL", minimumFractionDigits: 2, maximumFractionDigits: 2 })

    const result: CdiResponseDTO = {
        initialValue: formatNumber.format(response.initialValue as number),
        incomes: response.incomes.map(income => {
            return {
                income: formatNumber.format(income.income as number),
                tax: formatNumber.format(income.tax as number),
                netValue: formatNumber.format(income.netValue as number),
                month: income.month
            }
        })
    }
    return result
}