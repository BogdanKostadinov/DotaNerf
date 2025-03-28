import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

export interface SelectItem {
  id: string | number;
  label: string;
}

@Component({
  selector: 'app-select-with-search',
  templateUrl: './select-with-search.component.html',
  styleUrl: './select-with-search.component.scss',
})
export class SelectWithSearchComponent {
  @Input() label = '';
  @Input() control: FormControl<string | string[] | number | null> =
    new FormControl();
  @Input() items: SelectItem[] = [];
}
