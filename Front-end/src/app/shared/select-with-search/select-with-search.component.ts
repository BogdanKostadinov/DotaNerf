import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { map, Observable, startWith, Subject, takeUntil } from 'rxjs';

export interface SelectItem {
  id: string | number;
  label: string;
}

@Component({
  selector: 'app-select-with-search',
  templateUrl: './select-with-search.component.html',
  styleUrl: './select-with-search.component.scss',
})
export class SelectWithSearchComponent implements OnInit, OnDestroy {
  @Input() label = '';
  @Input() control: FormControl<string | string[] | number | null> =
    new FormControl();
  @Input() items: SelectItem[] = [];

  searchCtrl = new FormControl('');
  filteredItems$!: Observable<SelectItem[]>;
  private destroy$ = new Subject<void>();

  ngOnInit() {
    this.filteredItems$ = this.searchCtrl.valueChanges.pipe(
      startWith(''),
      takeUntil(this.destroy$),
      map((search) => this.filterItems(search || '')),
    );
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  private filterItems(search: string): SelectItem[] {
    const searchTerm = search.toLowerCase();
    return this.items.filter((item) =>
      item.label.toLowerCase().includes(searchTerm),
    );
  }
}
