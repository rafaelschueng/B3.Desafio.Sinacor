import { environment } from '../../environments/environment';
import { Component } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { HttpRequest } from './http/http';
import { CdiResponseDTO } from '../types/CdiResponseDTO';
import { AdaptToPt_BR } from './adapter/adapter';

@Component({
  standalone: true,
  selector: 'app-root',
  imports: [ReactiveFormsModule],
  templateUrl: "./app.component.html",
})
export class AppComponent {

  public showErrorModal: boolean = false;
  public messageErrorModal: string = '';

  public value = new FormControl<number>(0);
  public months = new FormControl<number>(0);

  public CdiTableResponse: CdiResponseDTO | null = null;

  #endpoint = new URL(environment.apiUrl);

  public isValidMonth(months: number) {
    if (months === null) throw new Error("O valor de 'meses' não pode ser nulo!")
    if (months <= 0) throw new Error("O número de meses deve ser maior que 0!")
  };

  public isValidValue(value: number) {
    if (value === null) throw new Error("O valor a ser depositadonão pode ser nulo!")
    if (value <= 0) throw new Error("O valor para ser calculado deve ser maior que 0!")
  };

  public async fetchCdi() {
    const value = this.value.value?.toString() ?? "";
    const months = this.months.value?.toString() ?? "";
    this.#endpoint.searchParams.set("value", value)
    this.#endpoint.searchParams.set("months", months)

    const response = await HttpRequest<CdiResponseDTO>(this.#endpoint, "post");
    this.CdiTableResponse = AdaptToPt_BR(response);
    console.log(this.CdiTableResponse)
  }

  public validate() {
    try {
      this.isValidMonth(this.months.value as number)
      this.isValidValue(this.value.value as number)
      return true;
    } catch (error) {
      this.messageErrorModal = (error as Error).message;
      this.showErrorModal = true
      return false
    }
  }

  public closeError() {
    this.showErrorModal = false
  }

  public async submit() {
    if (!this.validate()) return;
    await this.fetchCdi()
  }
}