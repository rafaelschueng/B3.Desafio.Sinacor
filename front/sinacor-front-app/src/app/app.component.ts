import { Component } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

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

  public isValidMonth(months: number) {
    if (months === null) throw new Error("O valor de 'meses' não pode ser nulo!")
    if (months <= 0) throw new Error("O número de meses deve ser maior que 0!")
  };

  public isValidValue(value: number) {
    if (value === null) throw new Error("O valor a ser depositadonão pode ser nulo!")
    if (value <= 0) throw new Error("O valor para ser calculado deve ser maior que 0!")
  };

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

  public closeError () {
    this.showErrorModal = false
  }

  public submit() {
    if (!this.validate()) return;
    alert(`Valor inicial: ${this.value.value} e quantidade de meses ${this.months.value}`);
  }
}