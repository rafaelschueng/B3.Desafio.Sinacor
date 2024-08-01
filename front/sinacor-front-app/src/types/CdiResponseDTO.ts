export type CdiResponseDTO = {
    initialValue: number | string,
    "incomes": Array<Income>
}

export type Income = {
    income: number | string,
    netValue: number | string,
    tax: number | string,
    month: string
}