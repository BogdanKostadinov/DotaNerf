import { Component, EventEmitter, Input, Output } from '@angular/core';
import { SelectItem } from '../select-with-search/select-with-search.component';

@Component({
  selector: 'app-shared-chip',
  templateUrl: './shared-chip.component.html',
  styleUrl: './shared-chip.component.scss',
})
export class SharedChipComponent {
  @Input() chipItems: SelectItem[] = [];
  @Output() chipsSelected = new EventEmitter<SelectItem[]>();

  selectedChips: SelectItem[] = [];

  selectChip(event: any, chip: SelectItem) {
    if (event.selected) {
      this.selectedChips.push(chip);
    } else {
      this.selectedChips = this.selectedChips.filter((c) => c.id !== chip.id);
    }
    this.chipsSelected.emit(this.selectedChips);
  }
}
