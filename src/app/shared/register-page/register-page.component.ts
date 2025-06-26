import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrl: './register-page.component.scss',
})
export class RegisterPageComponent {
  registerForm: FormGroup;
  hidePassword = true;
  hideConfirm = true;

  constructor(private fb: FormBuilder) {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
    });

    this.registerForm.get('confirmPassword')?.valueChanges.subscribe(() => {
      this.checkPasswordMatch();
    });
    this.registerForm.get('password')?.valueChanges.subscribe(() => {
      if (this.registerForm.get('confirmPassword')?.value) {
        this.checkPasswordMatch();
      }
    });
  }

  private checkPasswordMatch() {
    const password = this.registerForm.get('password')?.value;
    const confirmPassword = this.registerForm.get('confirmPassword')?.value;

    if (password !== confirmPassword) {
      this.registerForm
        .get('confirmPassword')
        ?.setErrors({ passwordMismatch: true });
    } else {
      // Only clear the passwordMismatch error, not other errors
      const errors = this.registerForm.get('confirmPassword')?.errors;
      if (errors) {
        delete errors['passwordMismatch'];
        const hasOtherErrors = Object.keys(errors).length > 0;
        this.registerForm
          .get('confirmPassword')
          ?.setErrors(hasOtherErrors ? errors : null);
      }
    }
  }

  onSubmit() {
    if (this.registerForm.valid) {
      console.log('Form submitted:', this.registerForm.value);
    }
  }
}
